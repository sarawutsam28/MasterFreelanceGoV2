﻿using System;
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
    public class HomeController : Controller
    {

        private readonly dDbContext _context;
        private readonly IHostingEnvironment _env;
        public HomeController(dDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            //   SaveProject();
            return View();
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Register()
        {

            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult ProfileFreelance()
        {
            return View();
        }
        public IActionResult ProfileEmployer(int id)
        {
            var Employer_ID = HttpContext.Session.GetInt32("Employer_ID");
            if (Employer_ID == null)
            {
                return RedirectToAction(nameof(Login));
            }
            var ProfileEmployer = _context.Employer.SingleOrDefault(e => e.Employer_ID == id);
            var ProjectEmployer = _context.Project.Where(p => p.Employer_ID == id && p.DelStatus == false);
            ViewData["ProfileEmployer"] = ProfileEmployer;
            ViewData["ProjectEmployer"] = ProjectEmployer;
            return View();
        }
        public IActionResult ProfileDetailsEmployer(int id)
        {
            var ProfileDetailsEmployer = _context.Employer.SingleOrDefault(e => e.Employer_ID == id);
            ViewData["ProfileDetailsEmployer"] = ProfileDetailsEmployer;
            return View();
        }
        public IActionResult UpdateProfileEmployer(int id)
        {
            var UpdateProfileEmployer = _context.Employer.SingleOrDefault(e => e.Employer_ID == id);
            ViewData["UpdateProfileEmployer"] = UpdateProfileEmployer;
            return View();
        }
        public async Task<IActionResult> UpdateEmployer(Employer Employer)
        {
            var _Employer = _context.Employer.SingleOrDefault(e => e.Employer_ID == Employer.Employer_ID);
            _Employer.FullName = Employer.FullName;
            _Employer.Email = Employer.Email;
            _Employer.TelephoneNumber = Employer.TelephoneNumber;
            _Employer.Facebook = Employer.Facebook;
            _Employer.Line = Employer.Line;
            _Employer.Address = Employer.Address;
            _Employer.imgName = Employer.imgName;
            _Employer.Date_Update = DateTime.Now;
            _context.Update(_Employer);
            await _context.SaveChangesAsync();
            return Json(new { Result = "OK" });
        }
        public IActionResult ProfileCompany(int id)
        {
            var Company_ID = HttpContext.Session.GetInt32("Company_ID");
            if (Company_ID == null)
            {
                return RedirectToAction(nameof(Login));
            }
            var ProfileCompany = _context.Company.SingleOrDefault(e => e.Company_ID == id);
            var ProjectCompany = _context.Project.Where(p => p.Company_ID == id && p.DelStatus == false);
            ViewData["ProfileCompany"] = ProfileCompany;
            ViewData["ProjectCompany"] = ProjectCompany;
            return View();
        }
        public IActionResult ProjectDetails(int id)
        {
            var ProjectDetails = _context.Project.SingleOrDefault(p => p.Project_ID == id);

            _context.Entry(ProjectDetails)
            .Reference(b => b.Employer)
            .Load();
            ViewData["ProjectDetails"] = ProjectDetails;
            return View();
        }
        public IActionResult UpdateSkill()
        {
            var Skill = _context.Skill.ToList();
            ViewData["Skill"] = Skill;
            return View();
        }
        public IActionResult ProjectPost()
        {
            return View();
        }
        public IActionResult UpdateProjectSkill(int[] skillList)
        {
            var SessionProject_ID = HttpContext.Session.GetInt32("Project_ID");

            foreach (var skillLists in skillList)
            {
                var _ProjectSkill = new ProjectSkill
                {
                    Skill_ID = skillLists,
                    Project_ID = (int)SessionProject_ID,
                    Date_Create = DateTime.Now,
                    Date_Update = DateTime.Now,
                    DelStatus = false,
                };
                _context.ProjectSkill.Add(_ProjectSkill);
                _context.SaveChanges();
            }

            return Json(new { Result = "OK" });
        }
        public IActionResult DelProjectSkill()
        {
            var _Project = _context.ProjectSkill.Where(p => p.Project_ID == 29).ToList();

            foreach (var _Projects in _Project)
            {
                _context.ProjectSkill.Remove(_Projects);
                _context.SaveChanges();
            }
            return Json(new { Result = "OK" });
        }
        [HttpPost]
        public IActionResult EmployerRegister(Employer Employer)
        {
            Employer.imgName = "defaultImg.jpg";
            Employer.Date_Create = DateTime.Now;
            Employer.Date_Update = DateTime.Now;
            Employer.DelStatus = false;
            _context.Add(Employer);
            _context.SaveChanges();
            return Json(new { Result = Employer });
        }
        [HttpPost]
        public IActionResult CompanyRegister(Company Company)
        {
            Company.imgName = "defaultImg.jpg";
            Company.Date_Create = DateTime.Now;
            Company.Date_Update = DateTime.Now;
            Company.DelStatus = false;
            _context.Add(Company);
            _context.SaveChanges();
            return Json(new { Result = Company });
        }
        [HttpPost]
        public IActionResult FreelanceRegister(Freelance Freelance)
        {
            var _Freelance = new Freelance
            {
                UserName = Freelance.UserName,
                Password = Freelance.Password,
                FullName = Freelance.FullName,
                ID_Card = Freelance.ID_Card,
                Email = Freelance.Email,
                TelephoneNumber = Freelance.TelephoneNumber,
                Facebook = Freelance.Facebook,
                Line = Freelance.Line,
                Address = Freelance.Address,
                ImgName = "defaultImg.jpg",
                Date_Create = DateTime.Now,
                Date_Update = DateTime.Now,
                DelStatus = false,
            };
            _context.Add(_Freelance);
            _context.SaveChanges();
            return Json(new { Result = _Freelance });
        }
        [HttpPost]
        public IActionResult LoginFreelance(Freelance Freelance)
        {
            var loginde = _context.Freelance
                .Single(f => f.UserName == Freelance.UserName && f.Password == Freelance.Password);
            HttpContext.Session.SetInt32("ID", loginde.Freelance_ID);
            ViewData["Freelance_ID"] = loginde.Freelance_ID;
            return Json(new { Result = loginde });
        }
        [HttpPost]
        public IActionResult LoginEmployer(Employer Employer)
        {
            var loginde = _context.Employer
                .Single(f => f.UserName == Employer.UserName && f.Password == Employer.Password);
            HttpContext.Session.SetInt32("Employer_ID", loginde.Employer_ID);
            ViewData["Employer_ID"] = loginde.Employer_ID;
            return Json(new { Result = loginde });
        }
        [HttpPost]
        public IActionResult LoginCompany(Company Company)
        {
            var loginde = _context.Company
                .Single(f => f.UserName == Company.UserName && f.Password == Company.Password);
            HttpContext.Session.SetInt32("Company_ID", loginde.Company_ID);
            ViewData["Company_ID"] = loginde.Company_ID;
            return Json(new { Result = loginde });
        }
        [HttpPost]
        public async Task<IActionResult> SaveProject(Project Project)
        {
            var _Project = new Project
            {
                Employer_ID = (int)HttpContext.Session.GetInt32("Employer_ID"),
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
        public async Task<IActionResult> SaveProjectCompany(Project Project)
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
        public IActionResult GetProjectSkill(int id)
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
            return Json(SkillProject);
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
            _Project.Date_Update = DateTime.Now;
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
        public JsonResult ProjectLisr()
        {
            try
            {
                List<Project> project = _context.Project.ToList();
                return Json(new { Result = "OK", Records = project });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        public async Task<IActionResult> SaveSkill(string skill)
        {
            var skil = new Skill
            {
                Name = skill,
                Skill_Description = "programing language",
                Date_Create = DateTime.Now,
                Date_Update = DateTime.Now,
                DelStatus = false,
            };
            _context.Skill.Add(skil);
            await _context.SaveChangesAsync();
            return Json(new { Result = "OK" });
        }
        public async Task<IActionResult> GetProject()
        {
            var _Project = _context.Project
            .Select(d =>
            new
            {
                // pppp = Project.Select(p => d.Project_ID == 1),
                project = d.Freelance,
                ProjectName = d.ProjectName,
                ProjectSkill = d.ProjectSkill.Select(g => g.Skill.Name).ToList()
            }
            ).ToList();
            //    var a = _context.Project.Select(p => p.Project_ID == 1)
            var results = _Project;

            return Json(new { Result = results });
        }
        public async Task<IActionResult> GetProjectById(int id)
        {
            var _Project = _context.Project
            .Select(d =>
            new
            {
                _Project = d.Project_ID,
                Freelance = d.Freelance,
                ProjectSkill = d.ProjectSkill.Select(g => g.Skill.Name).ToList()
            }
            );
            var results = _Project;

            return Json(new { Result = _Project });
        }
        [HttpPost]
        public async Task<IActionResult> Upload(UploadImg model)
        {
            var file = model.file;
            if (file.Length == 0)
            {
                return Json(new { Result = "NullImg" });
            }
            if (file.Length > 0)
            {
                string path = Path.Combine(_env.WebRootPath, "images");
                using (var fs = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                {
                    await file.CopyToAsync(fs);
                }
                model.Source = $"/images/{(file.FileName)}";
                model.Extension = Path.GetExtension(file.FileName).Substring(1);

                return Ok(model);
            }
            return Json(new { Result = "NullImg" });
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
