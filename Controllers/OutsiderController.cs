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
            var ProjectDetails = _context.Project.SingleOrDefault(p => p.Project_ID == id);

            _context.Entry(ProjectDetails)
            .Reference(b => b.Employer)
            .Load();
            _context.Entry(ProjectDetails)
           .Reference(b => b.Company)
           .Load();
            ViewData["ProjectDetails"] = ProjectDetails;
            return View();
        }
        public IActionResult ProfileDetailsEmployer(int id)
        {
            var ProfileDetailsEmployer = _context.Employer.SingleOrDefault(e => e.Employer_ID == id);
            ViewData["ProfileDetailsEmployer"] = ProfileDetailsEmployer;
            return View();
        }
        public IActionResult ProfileDetailsCompany(int id)
        {
            var ProfileDetailsCompany = _context.Company.SingleOrDefault(e => e.Company_ID == id);
            ViewData["ProfileDetailsCompany"] = ProfileDetailsCompany;
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
