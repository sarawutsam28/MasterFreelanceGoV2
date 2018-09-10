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
        public IActionResult SearchProject()
        {
            var TypeProject = _context.TypeProject.Where(s => s.DelStatus == false).ToList();
            ViewData["TypeProject"] = TypeProject;
            var ProjectList = _context.Project.Where(p => p.ProjectStatus == true && p.DelStatus != true && p.Freelance_ID == null);
            ViewData["ProjectList"] = ProjectList;

            return View();
        }
        public async Task<IActionResult> SearchString(string searchString, int typeProject)
        {
            var _Project = from m in _context.Project
                           select m;
            if (searchString != null)
            {
                if (typeProject == 0)
                {
                    if (!String.IsNullOrEmpty(searchString))
                    {
                        _Project = _Project.Where(s => s.ProjectName.Contains(searchString) || s.Description.Contains(searchString));
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(searchString))
                    {
                        _Project = _Project.Where(s => s.ProjectName.Contains(searchString) || s.Description.Contains(searchString) && s.TypeProject_ID == typeProject);
                    }
                }
            }
            else
            {
                _Project = _Project.Where(s => s.TypeProject_ID == typeProject);
            }
            _Project = _Project.Where(p => p.DelStatus == false && p.Freelance_ID == null && p.ProjectStatus == true);
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
            _context.Entry(ProjectDetails)
            .Reference(b => b.TypeProject)
            .Load();
            var AuctionList = _context.Auction.Where(a => a.Project_ID == id)
           .Include(x => x.Project)
           .Include(x => x.Freelance).ToList();
            ViewData["AuctionList"] = AuctionList;
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
                    Rating = d.Freelance.Rating,
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
            var ProjectFreelance = _context.FreelanceRating.Where(p => p.Employer_ID == id)
            .Include(p => p.Project)
            .Include(p => p.Project.Freelance)
            .ToList();
            ViewData["ProjectFreelance"] = ProjectFreelance;
            ViewData["ProfileDetailsFreelance"] = ProfileDetailsFreelance;
            return View();
        }
        public IActionResult GetAuctionFreelance(int id)
        {
            var Freelance = _context.Freelance.SingleOrDefault(p => p.Freelance_ID == id);
            var GetProjectAuction = _context.Entry(Freelance)
                .Collection(b => b.Auction)
                .Query()
                .Where(l => l.Project.Freelance == null)
                .Select(d => new
                {
                    Project_ID = d.Project_ID,
                    ProjectName = d.Project.ProjectName,
                    Price = d.Price,
                    AuctionTime = d.AuctionTime,
                    EndDate = d.Project.EndDate,
                })
                .ToList();
            /* var xxx = _context.Project.Where(p => p.Freelance_ID == id)
             .Include(a => a.Freelance)
             .ToList();*/
            return Json(GetProjectAuction);
        }
        public IActionResult UpdateProfileFreelance(int id)
        {
            var UpdateProfileFreelance = _context.Freelance.SingleOrDefault(e => e.Freelance_ID == id);
            var Skill = _context.Skill.Where(s => s.DelStatus == false).ToList();
            ViewData["Skill"] = Skill;
            ViewData["UpdateProfileFreelance"] = UpdateProfileFreelance;
            return View();
        }
        public async Task<IActionResult> UpdateFreelance(Freelance Freelance)
        {
            var _Freelance = _context.Freelance.SingleOrDefault(e => e.Freelance_ID == Freelance.Freelance_ID);
            _Freelance.FullName = Freelance.FullName;
            _Freelance.Email = Freelance.Email;
            _Freelance.TelephoneNumber = Freelance.TelephoneNumber;
            _Freelance.Facebook = Freelance.Facebook;
            _Freelance.Line = Freelance.Line;
            _Freelance.Address = Freelance.Address;
            _Freelance.ImgName = Freelance.ImgName;
            _Freelance.Date_Update = DateTime.Now;
            _context.Update(_Freelance);
            await _context.SaveChangesAsync();
            return Json(new { result = _Freelance });
        }
        public IActionResult UpdateSkillFreelance(int id, int[] skills)
        {
            var _FreelanceSkill = _context.FreelanceSkill.Where(p => p.Freelance_ID == id).ToArray();
            if (_FreelanceSkill.Length == 0)
            {
                foreach (var skillLists in skills)
                {
                    var _Skill = new FreelanceSkill
                    {
                        Skill_ID = skillLists,
                        Freelance_ID = id,
                        Date_Create = DateTime.Now,
                        Date_Update = DateTime.Now,
                        DelStatus = false,
                    };
                    _context.FreelanceSkill.Add(_Skill);
                    _context.SaveChanges();
                }
            }
            else
            {
                foreach (var _SkillFreelance in _FreelanceSkill)
                {
                    _context.FreelanceSkill.Remove(_SkillFreelance);
                    _context.SaveChanges();
                }
                foreach (var skillLists in skills)
                {
                    var _FreelanceSkillList = new FreelanceSkill
                    {
                        Skill_ID = skillLists,
                        Freelance_ID = id,
                        Date_Create = DateTime.Now,
                        Date_Update = DateTime.Now,
                        DelStatus = false,
                    };
                    _context.FreelanceSkill.Add(_FreelanceSkillList);
                    _context.SaveChanges();
                }

            }
            var Results = new { id, skills };
            return Json(new { Result = "OK" });
        }
        public IActionResult GetFreelanceSkill(int id)
        {
            var _Freelance = _context.Freelance.SingleOrDefault(p => p.Freelance_ID == id);
            var SkillFreelance = _context.Entry(_Freelance)
                .Collection(b => b.FreelanceSkill)
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
            return Json(SkillFreelance);
        }
        public IActionResult HistoryProjectDetails(int id)
        {
            var Project = _context.Project.SingleOrDefault(p => p.Project_ID == id);
            _context.Entry(Project)
            .Reference(b => b.Employer)
            .Load();
            _context.Entry(Project)
            .Reference(b => b.Freelance)
            .Load();
            _context.Entry(Project)
            .Reference(b => b.Company)
            .Load();
            ViewData["Project"] = Project;
            return View();
        }
        public IActionResult Rating(int id)
        {
            var Freelance_ID = HttpContext.Session.GetInt32("Freelance_ID");
            if (Freelance_ID == null)
            {
                return RedirectToAction("Login", "Home");
            }
            var _Project = _context.Project.SingleOrDefault(p => p.Project_ID == id);
            ViewData["_Project"] = _Project;
            return View();
        }
        public async Task<IActionResult> SaveEmployerRating(EmployerRating EmployerRating)
        {
            var _Project = _context.Project.SingleOrDefault(p => p.Project_ID == EmployerRating.Project_ID);
            _Project.FreelanceSuccessStatus = true;
            var Freelance_ID = HttpContext.Session.GetInt32("Freelance_ID");
            EmployerRating.Freelance_ID = Freelance_ID;
            EmployerRating.Date_Create = DateTime.Now;
            _context.Update(_Project);
            _context.EmployerRating.Add(EmployerRating);
            await _context.SaveChangesAsync();
            //updateRating
            if (EmployerRating.Employer_ID != null)
            {
                var _Rating = _context.EmployerRating.Where(r => r.Employer_ID == EmployerRating.Employer_ID).ToArray();
                var Length = _Rating.Length;
                int sum = 0;
                foreach (var _Ratings in _Rating)
                {
                    sum = sum + _Ratings.Score;
                }
                int RatingEm = sum / Length;
                var Employerdata = _context.Employer.SingleOrDefault(e => e.Employer_ID == EmployerRating.Employer_ID);
                Employerdata.Rating = RatingEm;
                _context.Update(Employerdata);
                await _context.SaveChangesAsync();
            }
            if (EmployerRating.Company_ID != null)
            {
                var _Rating = _context.EmployerRating.Where(r => r.Company_ID == EmployerRating.Company_ID).ToArray();
                var Length = _Rating.Length;
                int sum = 0;
                foreach (var _Ratings in _Rating)
                {
                    sum = sum + _Ratings.Score;
                }
                int RatingCom = sum / Length;
                var Company = _context.Company.SingleOrDefault(e => e.Company_ID == EmployerRating.Company_ID);
                Company.Rating = RatingCom;
                _context.Update(Company);
                await _context.SaveChangesAsync();
            }
            return Json(new { result = EmployerRating });
        }
        public IActionResult ProjectDetailsWorking(int id)
        {
            var ProjectDetails = _context.Project.SingleOrDefault(p => p.Project_ID == id);

            _context.Entry(ProjectDetails)
            .Reference(b => b.Employer)
            .Load();
            _context.Entry(ProjectDetails)
            .Reference(b => b.Company)
            .Load();
            _context.Entry(ProjectDetails)
            .Reference(b => b.Freelance)
            .Load();
            HttpContext.Session.SetInt32("ProjectAcceptFreelanceId", id);
            ViewData["ProjectDetails"] = ProjectDetails;
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
