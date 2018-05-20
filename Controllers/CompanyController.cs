using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FreelanceGo_MasterV2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.IO;


namespace FreelanceGo_MasterV2.Controllers
{
    public class CompanyController : Controller
    {

        private readonly dDbContext _context;
        private readonly IHostingEnvironment _env;
        public CompanyController(dDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProjectPost()
        {
            return View();
        }
        public IActionResult ProfileDetailsCompany(int id)
        {
            var ProfileDetailsCompany = _context.Company.SingleOrDefault(e => e.Company_ID == id);
            ViewData["ProfileDetailsCompany"] = ProfileDetailsCompany;
            return View();
        }
        public IActionResult ProjectDetails(int id)
        {
            var ProjectDetails = _context.Project.SingleOrDefault(p => p.Project_ID == id);

            _context.Entry(ProjectDetails)
            .Reference(b => b.Company)
            .Load();
            ViewData["ProjectDetails"] = ProjectDetails;
            return View();
        }
        public async Task<IActionResult> SaveProject(Project Project)
        {
            var _Project = new Project
            {
                Company_ID = (int)HttpContext.Session.GetInt32("Company_ID"),
                ProjectName = Project.ProjectName,
                Description = Project.Description,
                Budget = Project.Budget,
                Timelength = Project.Timelength,
                StartingDate = Project.StartingDate,
                EndDate = Project.EndDate,
                ProjectStatus = true,
                ProjectTimeOut = DateTime.Now.AddDays(15),
                Date_Create = DateTime.Now,
                Date_Update = DateTime.Now,
                DelStatus = false,
            };
            _context.Project.Add(_Project);
            await _context.SaveChangesAsync();
            int id = _Project.Project_ID;
            HttpContext.Session.SetInt32("Project_ID", id);
            return Json(new { Result = id });
        }
        public IActionResult UpdateSkill()
        {
            var Skill = _context.Skill.ToList();
            ViewData["Skill"] = Skill;
            return View();
        }
        public async Task<IActionResult> UpdateCompany(Company Company)
        {
            var _Company = _context.Company.SingleOrDefault(e => e.Company_ID == Company.Company_ID);
            _Company.Company_Name = Company.Company_Name;
            _Company.Email = Company.Email;
            _Company.Company_Tel = Company.Company_Tel;
            _Company.Fax = Company.Fax;
            _Company.Company_TaxID = Company.Company_TaxID;
            _Company.Facebook = Company.Facebook;
            _Company.Line = Company.Line;
            _Company.Company_Address = Company.Company_Address;
            _Company.imgName = Company.imgName;
            _Company.Date_Update = DateTime.Now;
            _context.Update(_Company);
            await _context.SaveChangesAsync();
            return Json(new { Result = Company });
        }
        public IActionResult UpdateProfileCompany(int id)
        {
            var UpdateProfileCompany = _context.Company.SingleOrDefault(e => e.Company_ID == id);
            ViewData["UpdateProfileCompany"] = UpdateProfileCompany;
            return View();
        }
        public IActionResult UpdateProject(int id)
        {
            var UpdateProject = _context.Project.SingleOrDefault(p => p.Project_ID == id);
            var SkillProject = _context.Entry(UpdateProject)
                .Collection(b => b.ProjectSkill)
                .Query()
                .Select(d => new
                {
                    Skill_ID = d.Skill_ID,
                    Name = d.Skill.Name,
                    Skill_Description = d.Skill.Skill_Description,
                    Date_Create = d.Skill.Date_Create,
                    Date_Update = d.Skill.Date_Update,
                    DelStatus = d.Skill.DelStatus,
                })
                .ToList();
            var Skill = _context.Skill.ToList();
            ViewData["UpdateProject"] = UpdateProject;
            ViewData["Skill"] = Skill;
            ViewData["SkillProject"] = SkillProject;
            return View();
        }
        public IActionResult UpdateProjectSave(Project Project)
        {
            var _Project = _context.Project.SingleOrDefault(p => p.Project_ID == Project.Project_ID);
            _Project.Project_ID = Project.Project_ID;
            _Project.ProjectName = Project.ProjectName;
            _Project.Description = Project.Description;
            _Project.Budget = Project.Budget;
            _Project.Timelength = Project.Timelength;
            _Project.StartingDate = Project.StartingDate;
            _Project.EndDate = Project.EndDate;
            _context.Update(_Project);
            _context.SaveChanges();
            return Json(new { Result = _Project });
        }
        public IActionResult UpdateSkillProject(int id, int[] skills)
        {
            var _Project = _context.ProjectSkill.Where(p => p.Project_ID == id).ToArray();
            if (_Project.Length == 0)
            {
                foreach (var skillLists in skills)
                {
                    var _ProjectSkill = new ProjectSkill
                    {
                        Skill_ID = skillLists,
                        Project_ID = id,
                        Date_Create = DateTime.Now,
                        Date_Update = DateTime.Now,
                        DelStatus = false,
                    };
                    _context.ProjectSkill.Add(_ProjectSkill);
                    _context.SaveChanges();
                }
            }
            else
            {
                foreach (var _Projects in _Project)
                {
                    _context.ProjectSkill.Remove(_Projects);
                    _context.SaveChanges();
                }
                foreach (var skillLists in skills)
                {
                    var _ProjectSkill = new ProjectSkill
                    {
                        Skill_ID = skillLists,
                        Project_ID = id,
                        Date_Create = DateTime.Now,
                        Date_Update = DateTime.Now,
                        DelStatus = false,
                    };
                    _context.ProjectSkill.Add(_ProjectSkill);
                    _context.SaveChanges();
                }

            }
            var Results = new { id, skills };
            return Json(new { Result = _Project });
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
