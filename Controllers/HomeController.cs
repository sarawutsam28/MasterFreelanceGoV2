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
            SaveSkill();

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
        public IActionResult ProfileDetails()
        {
            return View();
        }
        public IActionResult ProfileCompany()
        {
            return View();
        }
        public IActionResult ProjectDetails(int id)
        {
            var ProjectDetails = _context.Project.SingleOrDefault(p => p.Project_ID == id);
            /* var x1 = _context.Project
             .Select(m => new
             {
                 Employerx1 = m.Employer,
             });*/
            _context.Entry(ProjectDetails)
            .Reference(b => b.Employer)
            .Load();


            // var xxxxx = _context.Project.SingleOrDefault(p => p.Employer.Employer_ID == ProjectDetails.Employer_ID);
            /* var Employer = _context.Project.Select(p => new
             {
                 EmployerName = p.Employer,
             }).ToList();*/
            ViewData["ProjectDetails"] = ProjectDetails;
            return View();
        }
        public IActionResult UpdateSkill()
        {
            return View();
        }
        public IActionResult ProjectPost()
        {
            return View();
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
                // FreelanceSkill = new List<FreelanceSkill>
                // {
                //     new FreelanceSkill { Title = "Intro to C#" },
                //     new FreelanceSkill { Title = "Intro to VB.NET" },
                //     new FreelanceSkill { Title = "Intro to F#" }
                // }
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
            HttpContext.Session.SetInt32("Employer_ID", loginde.Company_ID);
            ViewData["Company_ID"] = loginde.Company_ID;
            return Json(new { Result = loginde });
        }
        [HttpPost]
        public async Task<IActionResult> SaveProject(Project Project)
        {
            var _Project = new Project
            {
                Employer_ID = (int)HttpContext.Session.GetInt32("Employer_ID"),
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
                /* ProjectSkill = new List<ProjectSkill>
                 {
                     new ProjectSkill{
                         Project_ID = 1,
                         Skill_ID = 1,
                         Date_Create = DateTime.Now,
                         Date_Update = DateTime.Now,
                         DelStatus = false,
                     },
                      new ProjectSkill{
                         Project_ID = 1,
                         Skill_ID = 1,
                         Date_Create = DateTime.Now,
                         Date_Update = DateTime.Now,
                         DelStatus = false,
                     },
                      new ProjectSkill{
                         Project_ID = 1,
                         Skill_ID = 1,
                         Date_Create = DateTime.Now,
                         Date_Update = DateTime.Now,
                         DelStatus = false,
                     }
                 }*/
            };
            _context.Project.Add(_Project);
            await _context.SaveChangesAsync();
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
        public async Task<IActionResult> SaveSkill()
        {
            var skil = new Skill
            {
                Name = "PHP",
                Skill_Description = "PHPNaja",
                Date_Create = DateTime.Now,
                Date_Update = DateTime.Now,
                DelStatus = false,
            };
            _context.Skill.Add(skil);
            await _context.SaveChangesAsync();
            return Json(new { Result = "OK" });
        }
        // public async Task<IActionResult> GetProject()
        // {
        //     var _Project = _context.Project
        //    .Include(Project => Project.Employer)
        //    .Include(Project => Project.Company)
        //    .Include(Project => Project.Freelance)
        //    .Include(Project => Project.Employer)
        //    .Include(Project => Project.ProjectSkill).ToList()
        //    .ToList();
        //     var ProjectSkill = _context.Project.Select(f => new { d = f.ProjectSkill }).ToList();
        //     var results = new { _Project = _Project, ProjectSkill = ProjectSkill };

        //     return Json(new { Result = results });
        // }
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
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
