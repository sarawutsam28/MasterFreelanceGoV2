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
    public class AdminController : Controller
    {
        private readonly dDbContext _context;
        private readonly IHostingEnvironment _env;
        public AdminController(dDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            HttpContext.Session.Clear();
            return View();
        }
        public IActionResult TypeProject()
        {
            var TypeProject = _context.TypeProject;
            ViewData["TypeProject"] = TypeProject;
            return View();
        }
        public IActionResult Dashboard()
        {
            var Admin_ID = HttpContext.Session.GetInt32("Admin_ID");
            if (Admin_ID == null)
            {
                return RedirectToAction("Index", "Admin");
            }
            var Freelance = _context.Freelance.Where(f => f.DelStatus == false).Count();
            //var FreelanceAll = _context.Freelance.Count();
            // var EmployerAll = _context.Employer.Count();
            // CompanyAll = _context.Company.Count();
            // ProjectAll = _context.Project.Count();
            var Employer = _context.Employer.Where(f => f.DelStatus == false).Count();
            var Company = _context.Company.Where(f => f.DelStatus == false).Count();
            var Project = _context.Project.Where(f => f.DelStatus == false).Count();
            var FreelanceDelCount = _context.Freelance.Where(f => f.DelStatus == true).Count();
            var EmployerDelCount = _context.Employer.Where(f => f.DelStatus == true).Count();
            var CompanyDelCount = _context.Company.Where(f => f.DelStatus == true).Count();
            var ProjectDelCount = _context.Project.Where(f => f.DelStatus == true).Count();
            // var allEmployerDelCount = EmployerDelCount + CompanyDelCount;
            //var allEmployer = EmployerAll + CompanyAll;
            //var FreelanceDelCountPer = (FreelanceDelCount / FreelanceAll) * 100;
            //var EmployerDelCountPer = (allEmployerDelCount / allEmployer) * 100;
            //var ProjectDelCountPer = (ProjectDelCount / ProjectAll) * 100;
            // ViewData["FreelanceDelCountPer"] = FreelanceDelCountPer;
            // ViewData["EmployerDelCountPer"] = EmployerDelCountPer;
            //["ProjectDelCountPer"] = ProjectDelCountPer;
            ViewData["FreelanceDelCount"] = FreelanceDelCount;
            ViewData["EmployerDelCount"] = EmployerDelCount + CompanyDelCount;
            ViewData["ProjectDelCount"] = ProjectDelCount;
            ViewData["Freelance"] = Freelance;
            ViewData["Employer"] = Employer;
            ViewData["Company"] = Company;
            ViewData["Project"] = Project;
            return View();
        }
        public IActionResult Project()
        {
            var ProjectList = _context.Project;
            ViewData["ProjectList"] = ProjectList;
            return View();
        }
        public IActionResult UsersFrelance()
        {
            var Freelance = _context.Freelance;
            ViewData["Freelance"] = Freelance;
            return View();
        }
        public IActionResult UsersEmployer()
        {
            var Employer = _context.Employer;
            ViewData["Employer"] = Employer;
            return View();
        }
        public IActionResult UsersCompany()
        {
            var Company = _context.Company;
            ViewData["Company"] = Company;
            return View();
        }
        public IActionResult Skills()
        {
            var Skills = _context.Skill;
            ViewData["Skills"] = Skills;
            return View();
        }
        public IActionResult GetProject(int id)
        {
            var project = _context.Project.SingleOrDefault(p => p.Project_ID == id);
            _context.Entry(project)
           .Reference(b => b.Employer)
           .Load();
            return Json(project);
        }
        // public IActionResult RegisterAdmin(Admin Admin)
        // {
        //     Admin.UserName = "adminGo";
        //     Admin.PassWord = "123qwe";
        //     Admin.DelStatus = false;
        //     Admin.Date_Create = DateTime.Now;
        //     Admin.Date_Update = DateTime.Now;
        //     _context.Add(Admin);
        //     _context.SaveChanges();
        //     return Json("Register-OK////");
        // }
        public IActionResult LoginAdmin(Admin Admin)
        {
            var loginde = _context.Admin
                .Single(f => f.UserName == Admin.UserName && f.PassWord == Admin.PassWord);
            HttpContext.Session.SetInt32("Admin_ID", loginde.Admin_ID);
            ViewData["Admin_ID"] = loginde.Admin_ID;
            return Json(new { Result = loginde });
        }
        public IActionResult ProjectDetails(int id)
        {
            var Employer_ID = HttpContext.Session.GetInt32("Freelance_ID");
            if (Employer_ID != null)
            {
                return RedirectToAction("ProjectDetails", "Freelnace", new { id = id });
            }
            var ProjectDetails = _context.Project.SingleOrDefault(p => p.Project_ID == id);
            _context.Entry(ProjectDetails)
           .Collection(b => b.Auction)
           .Load();
            _context.Entry(ProjectDetails)
            .Reference(b => b.Employer)
            .Load();
            _context.Entry(ProjectDetails)
           .Reference(b => b.Company)
           .Load();
            _context.Entry(ProjectDetails)
            .Reference(b => b.TypeProject)
            .Load();
            var AuctionList = _context.Auction.Where(a => a.Project_ID == id)
            .Include(x => x.Project)
            .Include(x => x.Freelance).ToList();
            ViewData["ProjectDetails"] = ProjectDetails;
            ViewData["AuctionList"] = AuctionList;
            return View();
        }
        public IActionResult RemoveProject(int id)
        {
            var project = _context.Project.SingleOrDefault(p => p.Project_ID == id);
            project.DelStatus = true;

            _context.Project.Update(project);
            _context.SaveChanges();
            var Admin_ID = HttpContext.Session.GetInt32("Admin_ID");
            return RedirectToAction("Project", "Admin", new { id = Admin_ID });
        }

        public IActionResult RecoverProject(int id)
        {
            var project = _context.Project.SingleOrDefault(p => p.Project_ID == id);
            project.DelStatus = false;

            _context.Project.Update(project);
            _context.SaveChanges();
            var Admin_ID = HttpContext.Session.GetInt32("Admin_ID");
            return RedirectToAction("Project", "Admin", new { id = Admin_ID });
        }
        public IActionResult RemoveFreelance(int id)
        {
            var Freelance = _context.Freelance.SingleOrDefault(p => p.Freelance_ID == id);
            Freelance.DelStatus = true;

            _context.Freelance.Update(Freelance);
            _context.SaveChanges();
            var Admin_ID = HttpContext.Session.GetInt32("Admin_ID");
            return RedirectToAction("UsersFrelance", "Admin", new { id = Admin_ID });
        }
        public IActionResult RecoverFreelance(int id)
        {
            var Freelance = _context.Freelance.SingleOrDefault(p => p.Freelance_ID == id);
            Freelance.DelStatus = false;

            _context.Freelance.Update(Freelance);
            _context.SaveChanges();
            var Admin_ID = HttpContext.Session.GetInt32("Admin_ID");
            return RedirectToAction("UsersFrelance", "Admin", new { id = Admin_ID });
        }
        public IActionResult RemoveEmployer(int id)
        {
            var Employer = _context.Employer.SingleOrDefault(p => p.Employer_ID == id);
            Employer.DelStatus = true;

            _context.Employer.Update(Employer);
            _context.SaveChanges();
            var Admin_ID = HttpContext.Session.GetInt32("Admin_ID");
            return RedirectToAction("UsersEmployer", "Admin", new { id = Admin_ID });
        }
        public IActionResult RecoverEmployer(int id)
        {
            var Employer = _context.Employer.SingleOrDefault(p => p.Employer_ID == id);
            Employer.DelStatus = false;

            _context.Employer.Update(Employer);
            _context.SaveChanges();
            var Admin_ID = HttpContext.Session.GetInt32("Admin_ID");
            return RedirectToAction("UsersEmployer", "Admin", new { id = Admin_ID });
        }
        public IActionResult RemoveCompany(int id)
        {
            var Company = _context.Company.SingleOrDefault(p => p.Company_ID == id);
            Company.DelStatus = true;

            _context.Company.Update(Company);
            _context.SaveChanges();
            var Admin_ID = HttpContext.Session.GetInt32("Admin_ID");
            return RedirectToAction("UsersCompany", "Admin", new { id = Admin_ID });
        }
        public IActionResult RecoverCompany(int id)
        {
            var Company = _context.Company.SingleOrDefault(p => p.Company_ID == id);
            Company.DelStatus = false;

            _context.Company.Update(Company);
            _context.SaveChanges();
            var Admin_ID = HttpContext.Session.GetInt32("Admin_ID");
            return RedirectToAction("UsersCompany", "Admin", new { id = Admin_ID });
        }
        public IActionResult RecoverSkill(int id)
        {
            var Skill = _context.Skill.SingleOrDefault(p => p.Skill_ID == id);
            Skill.DelStatus = false;

            _context.Skill.Update(Skill);
            _context.SaveChanges();
            var Admin_ID = HttpContext.Session.GetInt32("Admin_ID");
            return RedirectToAction("Skills", "Admin", new { id = Admin_ID });
        }
        public IActionResult RemoveSkill(int id)
        {
            var Skill = _context.Skill.SingleOrDefault(p => p.Skill_ID == id);
            Skill.DelStatus = true;

            _context.Skill.Update(Skill);
            _context.SaveChanges();
            var Admin_ID = HttpContext.Session.GetInt32("Admin_ID");
            return RedirectToAction("Skills", "Admin", new { id = Admin_ID });
        }
        public IActionResult RecoverTypeProject(int id)
        {
            var TypeProject = _context.TypeProject.SingleOrDefault(p => p.TypeProject_ID == id);
            TypeProject.DelStatus = false;

            _context.TypeProject.Update(TypeProject);
            _context.SaveChanges();
            var Admin_ID = HttpContext.Session.GetInt32("Admin_ID");
            return RedirectToAction("TypeProject", "Admin", new { id = Admin_ID });
        }
        public IActionResult RemoveTypeProject(int id)
        {
            var TypeProject = _context.TypeProject.SingleOrDefault(p => p.TypeProject_ID == id);
            TypeProject.DelStatus = true;

            _context.TypeProject.Update(TypeProject);
            _context.SaveChanges();
            var Admin_ID = HttpContext.Session.GetInt32("Admin_ID");
            return RedirectToAction("TypeProject", "Admin", new { id = Admin_ID });
        }
        public async Task<IActionResult> searchID(int searchID)
        {
            var _Project = _context.Project.Where(s => s.Project_ID == searchID);
            return Json(await _Project.ToListAsync());
        }
        public async Task<IActionResult> searchFreelanceID(int searchID)
        {
            var Freelance = _context.Freelance.Where(s => s.Freelance_ID == searchID);
            return Json(await Freelance.ToListAsync());
        }
        public async Task<IActionResult> searchEmployerID(int searchID)
        {
            var Employer = _context.Employer.Where(s => s.Employer_ID == searchID);
            return Json(await Employer.ToListAsync());
        }
        public async Task<IActionResult> searchCompanyID(int searchID)
        {
            var Company = _context.Company.Where(s => s.Company_ID == searchID);
            return Json(await Company.ToListAsync());
        }
        public IActionResult skillEdit(int id)
        {
            var nameSkill = _context.Skill.SingleOrDefault(s => s.Skill_ID == id);
            return Json(nameSkill);
        }
        public IActionResult TypeProjectEdit(int id)
        {
            var nameSkill = _context.TypeProject.SingleOrDefault(s => s.TypeProject_ID == id);
            return Json(nameSkill);
        }
        public IActionResult EditSkillSeve(Skill Skills)
        {
            Skills.Date_Update = DateTime.Now;
            _context.Update(Skills);
            _context.SaveChanges();
            return Json(Skills);
        }
        public IActionResult EditTypeProjectSeve(TypeProject TypeProject)
        {
            TypeProject.Date_Update = DateTime.Now;
            _context.Update(TypeProject);
            _context.SaveChanges();
            return Json(TypeProject);
        }
        public async Task<IActionResult> SaveSkill(Skill Skill)
        {
            var skil = new Skill
            {
                Name = Skill.Name,
                Skill_Description = Skill.Skill_Description,
                Date_Create = DateTime.Now,
                Date_Update = DateTime.Now,
                DelStatus = false,
            };
            _context.Skill.Add(skil);
            await _context.SaveChangesAsync();
            return Json(new { Result = "OK" });
        }
        public IActionResult AddTypeProject(TypeProject TypeProject)
        {
            TypeProject.Date_Create = DateTime.Now;
            TypeProject.Date_Update = DateTime.Now;
            TypeProject.DelStatus = false;
            _context.TypeProject.Add(TypeProject);
            _context.SaveChanges();
            return Json("OK");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
