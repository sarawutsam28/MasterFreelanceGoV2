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
    public class FreelnaceController : Controller
    {

        private readonly dDbContext _context;
        private readonly IHostingEnvironment _env;
        public FreelnaceController(dDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View();
        }
        //[Route("{searchString}/{item1}/{item2}/{item3}")]
        public async Task<IActionResult> SearchProject()
        {
            var searchString = "โคราช";
            var Skill = _context.Skill.ToList();
            ViewData["Skill"] = Skill;
            var _Project = from m in _context.Project
                           select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                _Project = _Project.Where(s => s.ProjectName.Contains(searchString) || s.Description.Contains(searchString));
            }
            var _ProjectList = await _Project.ToListAsync();
            HttpContext.Items[_ProjectList] = _ProjectList;

            ViewData["searchString"] = searchString;
            ViewData["_Project"] = await _Project.ToListAsync();
            return View();
        }
        public async Task<IActionResult> SearchString(string searchString = "สร้าง")
        {
            var _Project = from m in _context.Project
                           select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                _Project = _Project.Where(s => s.ProjectName.Contains(searchString) || s.Description.Contains(searchString));
            }

            ViewData["_Project"] = await _Project.ToListAsync();
            return Json(await _Project.ToListAsync());
        }
        public IActionResult ProjectDetails(int id)
        {
            var ProjectDetails = _context.Project.SingleOrDefault(p => p.Project_ID == id);
            // var Auction = _context.Auction.Where(a => a.Project_ID == id);
            _context.Entry(ProjectDetails)
            .Reference(b => b.Employer)
            .Load();
            _context.Entry(ProjectDetails)
           .Reference(b => b.Company)
           .Load();
            ViewData["ProjectDetails"] = ProjectDetails;
            /// ViewData["Auction"] = Auction;
            return View();
        }
        public IActionResult SaveAuction(Auction Auction)
        {
            var Freelance_ID = HttpContext.Session.GetInt32("Freelance_ID");
            var _Auction = new Auction
            {
                Freelance_ID = (int)Freelance_ID,
                Project_ID = Auction.Project_ID,
                Price = Auction.Price,
                AuctionTime = Auction.AuctionTime,
                Date_Create = DateTime.Now,
            };
            _context.Auction.Add(_Auction);
            _context.SaveChanges();
            return Json(new { Result = _Auction });
        }
        public IActionResult GetProjectAuction(int id)
        {
            var Project = _context.Project.SingleOrDefault(p => p.Project_ID == id);
            var GetProjectAuction = _context.Entry(Project)
                .Collection(b => b.Auction)
                .Query()
                .Select(d => new
                {
                    Auction_ID = d.Auction_ID,
                    FullName = d.Freelance.FullName,
                    Freelance_ID = d.Freelance_ID,
                    Price = d.Price,
                    AuctionTime = d.AuctionTime,
                    Date_Create = d.Date_Create,
                })
                .ToList();
            return Json(GetProjectAuction);
        }
        public IActionResult GetSkillsFreelance(int id)
        {
            var Project = _context.Freelance.SingleOrDefault(p => p.Freelance_ID == id);
            var GetProjectAuction = _context.Entry(Project)
                .Collection(b => b.FreelanceSkill)
                .Query()
                .Select(d => new
                {
                    Freelance_ID = d.Freelance_ID,
                    SkillName = d.Skill.Name,
                })
                .ToList();
            return Json(GetProjectAuction);
        }
        public IActionResult ProfileDetailsFreelance(int id)
        {
            var ProfileDetailsFreelance = _context.Freelance.SingleOrDefault(e => e.Freelance_ID == id);
            ViewData["ProfileDetailsFreelance"] = ProfileDetailsFreelance;
            return View();
        }
        public IActionResult GetAuctionFreelance(int id)
        {
            var Freelance = _context.Freelance.SingleOrDefault(p => p.Freelance_ID == id);
            var GetProjectAuction = _context.Entry(Freelance)
                .Collection(b => b.Auction)
                .Query()
                .Select(d => new
                {
                    Project_ID = d.Project_ID,
                    ProjectName = d.Project.ProjectName,
                    Price = d.AuctionTime,
                    EndDate = d.Project.EndDate,
                })
                .ToList();
            return Json(GetProjectAuction);
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
