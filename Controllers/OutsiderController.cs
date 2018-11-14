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
    public class OutsiderController : Controller
    {

        private readonly dDbContext _context;
        private readonly IHostingEnvironment _env;
        public OutsiderController(dDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProjectDetails(int id)
        {
            var Employer_IDs = HttpContext.Session.GetInt32("Employer_ID");
            var Company_ID = HttpContext.Session.GetInt32("Company_ID");
            var Freelance_ID = HttpContext.Session.GetInt32("Freelance_ID");
            var Admin_ID = HttpContext.Session.GetInt32("Admin_ID");
            if (Employer_IDs != null)
            {
                ViewData["NavStatus"] = "Employer";
            }
            if (Company_ID != null)
            {
                ViewData["NavStatus"] = "Company";
            }
            if (Freelance_ID != null)
            {
                ViewData["NavStatus"] = "Freelance";
            }
            if (Admin_ID != null)
            {
                ViewData["NavStatus"] = "Admin_ID";
            }
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
        public IActionResult ProfileDetailsEmployer(int id)
        {
            var Employer_ID = HttpContext.Session.GetInt32("Employer_ID");
            var Company_ID = HttpContext.Session.GetInt32("Company_ID");
            var Freelance_ID = HttpContext.Session.GetInt32("Freelance_ID");
            var Admin_ID = HttpContext.Session.GetInt32("Admin_ID");
            if (Employer_ID != null)
            {
                ViewData["NavStatus"] = "Employer";
            }
            if (Company_ID != null)
            {
                ViewData["NavStatus"] = "Company";
            }
            if (Freelance_ID != null)
            {
                ViewData["NavStatus"] = "Freelance";
            }
            if (Admin_ID != null)
            {
                ViewData["NavStatus"] = "Admin_ID";
            }
            var ProfileDetailsEmployer = _context.Employer.SingleOrDefault(e => e.Employer_ID == id);
            var ProjectEmployer = _context.EmployerRating.Where(p => p.Employer_ID == id)
            .Include(p => p.Project)
            .Include(p => p.Project.Freelance)
            .ToList();
            ViewData["ProfileDetailsEmployer"] = ProfileDetailsEmployer;
            ViewData["ProjectEmployer"] = ProjectEmployer;
            return View();
        }
        public IActionResult ProfileDetailsCompany(int id)
        {
            var Employer_ID = HttpContext.Session.GetInt32("Employer_ID");
            var Company_ID = HttpContext.Session.GetInt32("Company_ID");
            var Freelance_ID = HttpContext.Session.GetInt32("Freelance_ID");
            var Admin_ID = HttpContext.Session.GetInt32("Admin_ID");
            if (Employer_ID != null)
            {
                ViewData["NavStatus"] = "Employer";
            }
            if (Company_ID != null)
            {
                ViewData["NavStatus"] = "Company";
            }
            if (Freelance_ID != null)
            {
                ViewData["NavStatus"] = "Freelance";
            }
            if (Admin_ID != null)
            {
                ViewData["NavStatus"] = "Admin_ID";
            }
            var ProfileDetailsCompany = _context.Company.SingleOrDefault(e => e.Company_ID == id);
            var ProjectEmployer = _context.EmployerRating.Where(p => p.Company_ID == id)
            .Include(p => p.Project)
            .Include(p => p.Project.Freelance)
            .ToList();
            ViewData["ProjectEmployer"] = ProjectEmployer;
            ViewData["ProfileDetailsCompany"] = ProfileDetailsCompany;
            return View();
        }
        public IActionResult ProfileDetailsFreelance(int id)
        {
            var Employer_IDs = HttpContext.Session.GetInt32("Employer_ID");
            var Company_ID = HttpContext.Session.GetInt32("Company_ID");
            var Freelance_ID = HttpContext.Session.GetInt32("Freelance_ID");
            var Admin_ID = HttpContext.Session.GetInt32("Admin_ID");
            if (Employer_IDs != null)
            {
                ViewData["NavStatus"] = "Employer";
            }
            if (Company_ID != null)
            {
                ViewData["NavStatus"] = "Company";
            }
            if (Freelance_ID != null)
            {
                ViewData["NavStatus"] = "Freelance";
            }
            if (Admin_ID != null)
            {
                ViewData["NavStatus"] = "Admin_ID";
            }
            var ProfileDetailsFreelance = _context.Freelance.SingleOrDefault(e => e.Freelance_ID == id);
            var ProjectFreelance = _context.FreelanceRating.Where(p => p.Employer_ID == id)
            .Include(p => p.Project)
            .Include(p => p.Project.Freelance)
            .ToList();
            ViewData["ProjectFreelance"] = ProjectFreelance;
            ViewData["ProfileDetailsFreelance"] = ProfileDetailsFreelance;
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
