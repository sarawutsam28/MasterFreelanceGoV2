using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FreelanceGo_MasterV2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

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
        public IActionResult ProfileEmployer()
        {
            return View();
        }
        public IActionResult ProfileCompany()
        {
            return View();
        }
        public IActionResult UpdateSkill()
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
        public IActionResult LoginFreelance(Freelance Freelance)
        {
            var loginde = _context.Freelance
                .Single(f => f.UserName == Freelance.UserName && f.Password == Freelance.Password);
            HttpContext.Session.SetInt32("ID", loginde.Freelance_ID);
            ViewData["Freelance_ID"] = loginde.Freelance_ID;
            return Json(new { Result = loginde });
        }
        public IActionResult LoginEmployer(Employer Employer)
        {
            var loginde = _context.Employer
                .Single(f => f.UserName == Employer.UserName && f.Password == Employer.Password);
            HttpContext.Session.SetInt32("Employer_ID", loginde.Employer_ID);
            ViewData["Employer_ID"] = loginde.Employer_ID;
            return Json(new { Result = loginde });
        }
        public IActionResult LoginCompany(Company Company)
        {
            var loginde = _context.Company
                .Single(f => f.UserName == Company.UserName && f.Password == Company.Password);
            HttpContext.Session.SetInt32("Employer_ID", loginde.Company_ID);
            ViewData["Company_ID"] = loginde.Company_ID;
            return Json(new { Result = loginde });
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
