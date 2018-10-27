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
            TimersPro();
            var Freelance_ID = HttpContext.Session.GetInt32("Freelance_ID");
            var Employer_ID = HttpContext.Session.GetInt32("Employer_ID");
            var Company_ID = HttpContext.Session.GetInt32("Company_ID");
            var Admin_ID = HttpContext.Session.GetInt32("Admin_ID");
            if (Freelance_ID != null)
            {
                return RedirectToAction("ProfileFreelance", "Home", new { id = Freelance_ID });
                //return RedirectToAction(nameof(ProfileFreelance));
            }
            else if (Employer_ID != null)
            {
                return RedirectToAction("ProfileEmployer", "Home", new { id = Employer_ID });
            }
            else if (Company_ID != null)
            {
                return RedirectToAction("ProfileCompany", "Home", new { id = Company_ID });
            }
            else if (Admin_ID != null)
            {
                return RedirectToAction("Dashboard", "Admin", new { id = Admin_ID });
            }
            var Skill = _context.Skill.Where(s => s.DelStatus == false).ToList();
            var ProjectList = _context.Project.Where(p => p.ProjectStatus == true && p.DelStatus != true && p.Freelance_ID == null)
                .Include(p => p.ProjectSkill)
                    .ThenInclude(a => a.Skill)
                        .ToList();
            // foreach (Project ProjectLists in ProjectList)
            // {
            //     _context.Entry(ProjectLists)
            //     .Collection(b => b.ProjectSkill)
            //     .Load();
            // }
            var ProjectLength = _context.Project.Where(p => p.ProjectStatus != false && p.DelStatus != true && p.Freelance_ID == null).ToArray();
            var FreelanceLength = _context.Freelance.Where(p => p.DelStatus == false).ToArray();
            var EmployerLength = _context.Employer.Where(p => p.DelStatus == false).ToArray();
            var CompanyLength = _context.Company.Where(p => p.DelStatus == false).ToArray();
            var ProjectLengths = 0;
            var FreelanceLengths = 0;
            var EmployerLengths = 0;
            var CompanyLengths = 0;
            ProjectLengths = ProjectLength.Length;
            FreelanceLengths = FreelanceLength.Length;
            EmployerLengths = EmployerLength.Length;
            CompanyLengths = CompanyLength.Length;
            ViewData["EmployerLengths"] = EmployerLengths + CompanyLengths;
            ViewData["ProjectLengths"] = ProjectLengths;
            ViewData["FreelanceLengths"] = FreelanceLengths;
            ViewData["Skill"] = Skill;
            ViewData["ProjectList"] = ProjectList;
            var TypeProject = _context.TypeProject.Where(s => s.DelStatus == false).ToList();
            ViewData["TypeProject"] = TypeProject;
            return View();
        }
        public IActionResult Index1()
        {
            TimersPro();
            var Freelance_ID = HttpContext.Session.GetInt32("Freelance_ID");
            var Employer_ID = HttpContext.Session.GetInt32("Employer_ID");
            var Company_ID = HttpContext.Session.GetInt32("Company_ID");
            var Admin_ID = HttpContext.Session.GetInt32("Admin_ID");
            if (Freelance_ID != null)
            {
                return RedirectToAction("ProfileFreelance", "Home", new { id = Freelance_ID });
                //return RedirectToAction(nameof(ProfileFreelance));
            }
            else if (Employer_ID != null)
            {
                return RedirectToAction("ProfileEmployer", "Home", new { id = Employer_ID });
            }
            else if (Company_ID != null)
            {
                return RedirectToAction("ProfileCompany", "Home", new { id = Company_ID });
            }
            else if (Admin_ID != null)
            {
                return RedirectToAction("Dashboard", "Admin", new { id = Admin_ID });
            }
            var Skill = _context.Skill.Where(s => s.DelStatus == false).ToList();
            var ProjectList = _context.Project.Where(p => p.ProjectStatus == true && p.DelStatus != true && p.Freelance_ID == null)
                .Include(p => p.ProjectSkill)
                    .ThenInclude(a => a.Skill)
                        .ToList();
            // foreach (Project ProjectLists in ProjectList)
            // {
            //     _context.Entry(ProjectLists)
            //     .Collection(b => b.ProjectSkill)
            //     .Load();
            // }
            var ProjectLength = _context.Project.Where(p => p.ProjectStatus != false && p.DelStatus != true && p.Freelance_ID == null).ToArray();
            var FreelanceLength = _context.Freelance.Where(p => p.DelStatus == false).ToArray();
            var EmployerLength = _context.Employer.Where(p => p.DelStatus == false).ToArray();
            var CompanyLength = _context.Company.Where(p => p.DelStatus == false).ToArray();
            var ProjectLengths = 0;
            var FreelanceLengths = 0;
            var EmployerLengths = 0;
            var CompanyLengths = 0;
            ProjectLengths = ProjectLength.Length;
            FreelanceLengths = FreelanceLength.Length;
            EmployerLengths = EmployerLength.Length;
            CompanyLengths = CompanyLength.Length;
            ViewData["EmployerLengths"] = EmployerLengths + CompanyLengths;
            ViewData["ProjectLengths"] = ProjectLengths;
            ViewData["FreelanceLengths"] = FreelanceLengths;
            ViewData["Skill"] = Skill;
            ViewData["ProjectList"] = ProjectList;
            var TypeProject = _context.TypeProject.Where(s => s.DelStatus == false).ToList();
            ViewData["TypeProject"] = TypeProject;
            return View();
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

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
        public IActionResult SearchFreelance()
        {
            var Skill = _context.Skill.Where(s => s.DelStatus == false).ToList();
            ViewData["Skill"] = Skill;
            var _Freelance = _context.Freelance.Where(f => f.DelStatus == false)
            .Include(s => s.FreelanceSkill)
                .ThenInclude(a => a.Skill)
            .ToList();
            ViewData["_Freelance"] = _Freelance;
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Register()
        {
            var Skill = _context.Skill.Where(s => s.DelStatus == false).ToList();
            ViewData["Skill"] = Skill;
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult newLogin()
        {
            return View();
        }
        public IActionResult ProfileFreelance(int id)
        {
            TimersPro();
            var Freelance_ID = HttpContext.Session.GetInt32("Freelance_ID");
            if (Freelance_ID == null)
            {
                return RedirectToAction(nameof(Login));
            }
            var ProfileFreelance = _context.Freelance.SingleOrDefault(e => e.Freelance_ID == id);
            var ProjectFreelance = _context.Project.Where(p => p.Freelance_ID == id && p.DelStatus == false);
            ViewData["ProfileFreelance"] = ProfileFreelance;
            ViewData["ProjectFreelance"] = ProjectFreelance;
            return View();
        }
        public IActionResult ProfileEmployer(int id)
        {
            TimersPro();
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
            TimersPro();
            var ProfileDetailsEmployer = _context.Employer.SingleOrDefault(e => e.Employer_ID == id);
            var ProjectEmployer = _context.EmployerRating.Where(p => p.Employer_ID == id)
            .Include(p => p.Project)
            .Include(p => p.Project.Freelance)
            .ToList();
            ViewData["ProfileDetailsEmployer"] = ProfileDetailsEmployer;
            ViewData["ProjectEmployer"] = ProjectEmployer;
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
            TimersPro();
            var ProjectDetails = _context.Project.SingleOrDefault(p => p.Project_ID == id);

            _context.Entry(ProjectDetails)
            .Reference(b => b.Employer)
            .Load();
            _context.Entry(ProjectDetails)
           .Reference(b => b.TypeProject)
           .Load();
            HttpContext.Session.SetInt32("ProjectAcceptFreelanceId", id);
            ViewData["ProjectDetails"] = ProjectDetails;
            return View();
        }
        public IActionResult ProjectDetailsWorking(int id)
        {
            var ProjectDetails = _context.Project.SingleOrDefault(p => p.Project_ID == id);

            _context.Entry(ProjectDetails)
            .Reference(b => b.Employer)
            .Load();
            _context.Entry(ProjectDetails)
            .Reference(b => b.Freelance)
            .Load();
            HttpContext.Session.SetInt32("ProjectAcceptFreelanceId", id);
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
            TimersPro();
            var Employer_ID = HttpContext.Session.GetInt32("Employer_ID");
            if (Employer_ID == null)
            {
                return RedirectToAction(nameof(Login));
            }
            var Skill = _context.Skill.Where(s => s.DelStatus == false).ToList();
            ViewData["Skill"] = Skill;
            var TypeProject = _context.TypeProject.Where(s => s.DelStatus == false).ToList();
            ViewData["TypeProject"] = TypeProject;
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
        public IActionResult UpdateFreelanceSkill(int[] skillList, int id)
        {

            foreach (var skillLists in skillList)
            {
                var _FreelanceSkill = new FreelanceSkill
                {
                    Skill_ID = skillLists,
                    Freelance_ID = id,
                    Date_Create = DateTime.Now,
                    Date_Update = DateTime.Now,
                    DelStatus = false,
                };
                _context.FreelanceSkill.Add(_FreelanceSkill);
                _context.SaveChanges();
            }

            return Json(new { Result = skillList, idferrlance = id });
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
        public IActionResult FreelanceRegister(Freelance Freelance, int[] skillList)
        {
            var _Freelance = new Freelance
            {
                UserName = Freelance.UserName,
                Password = Freelance.Password,
                FullName = Freelance.FullName,
                TelephoneNumber = Freelance.TelephoneNumber,
                ID_Card = Freelance.ID_Card,
                Email = Freelance.Email,
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
            int id = _Freelance.Freelance_ID;
            foreach (var skillLists in skillList)
            {
                var _FreelanceSkill = new FreelanceSkill
                {
                    Skill_ID = skillLists,
                    Freelance_ID = id,
                    Date_Create = DateTime.Now,
                    Date_Update = DateTime.Now,
                    DelStatus = false,
                };
                _context.FreelanceSkill.Add(_FreelanceSkill);
                _context.SaveChanges();
            }
            return Json(new { Result = _Freelance, skillList = skillList });
        }
        [HttpPost]
        public IActionResult LoginFreelance(Freelance Freelance)
        {
            var loginde = _context.Freelance
                .Single(f => f.UserName == Freelance.UserName && f.Password == Freelance.Password && f.DelStatus == false);
            HttpContext.Session.SetInt32("Freelance_ID", loginde.Freelance_ID);
            ViewData["Freelance_ID"] = loginde.Freelance_ID;
            return Json(new { Result = loginde });
        }
        [HttpPost]
        public IActionResult LoginEmployer(Employer Employer)
        {
            var loginde = _context.Employer
                .Single(f => f.UserName == Employer.UserName && f.Password == Employer.Password && f.DelStatus == false);
            HttpContext.Session.SetInt32("Employer_ID", loginde.Employer_ID);
            ViewData["Employer_ID"] = loginde.Employer_ID;
            return Json(new { Result = loginde });
        }
        [HttpPost]
        public IActionResult LoginCompany(Company Company)
        {
            var loginde = _context.Company
                .Single(f => f.UserName == Company.UserName && f.Password == Company.Password && f.DelStatus == false);
            HttpContext.Session.SetInt32("Company_ID", loginde.Company_ID);
            ViewData["Company_ID"] = loginde.Company_ID;
            return Json(new { Result = loginde });
        }
        [HttpPost]
        public async Task<IActionResult> SaveProject(Project Project, int[] skillList, Boolean check1, Boolean check2)
        {
            var _Project = new Project
            {
                Employer_ID = (int)HttpContext.Session.GetInt32("Employer_ID"),
                ProjectName = Project.ProjectName,
                Description = Project.Description,
                TypeProject_ID = Project.TypeProject_ID,
                Budget = Project.Budget,
                Timelength = Project.Timelength,
                StartingDate = Project.StartingDate,
                EndDate = Project.EndDate,
                ProjectStatus = true,
                ProjectAuctionStatus = false,
                ProjectTimeOut = DateTime.Now.AddDays(15),
                Date_Create = DateTime.Now,
                Date_Update = DateTime.Now,
                DelStatus = false,
            };
            if (check1)
            {
                _Project.StartingDate = DateTime.Now;
                _Project.ProjectAuctionStatus = true;
            }
            if (check2)
            {
                _Project.EndDate = DateTime.Now.AddDays(15);
            }
            _context.Project.Add(_Project);
            await _context.SaveChangesAsync();
            int id = _Project.Project_ID;
            foreach (var skillLists in skillList)
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
            return Json(new { _Project });
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
            var Skill = _context.Skill.Where(s => s.DelStatus == false).ToList();
            var AuctionCount = _context.Auction.Where(a => a.Project_ID == id).Count();
            ViewData["AuctionCount"] = AuctionCount;
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
        public IActionResult AcceptFreelance(int id, int ProjectPrice, int ProjectTimelength)
        {
            var Employer_ID = HttpContext.Session.GetInt32("Employer_ID");
            var ProjectAcceptFreelanceId = HttpContext.Session.GetInt32("ProjectAcceptFreelanceId");
            var _ProjectAcceptFreelance = _context.Project.SingleOrDefault(p => p.Project_ID == ProjectAcceptFreelanceId);
            _ProjectAcceptFreelance.Freelance_ID = id;
            _ProjectAcceptFreelance.ProjectPrice = ProjectPrice;
            _ProjectAcceptFreelance.ProjectTimelength = ProjectTimelength;
            _context.Update(_ProjectAcceptFreelance);
            _context.SaveChanges();
            return RedirectToAction("ProfileEmployer", new { id = Employer_ID });
        }
        public IActionResult Rating(int id)
        {
            var Employer_ID = HttpContext.Session.GetInt32("Employer_ID");
            if (Employer_ID == null)
            {
                return RedirectToAction(nameof(Login));
            }
            var _Project = _context.Project.SingleOrDefault(p => p.Project_ID == id);
            ViewData["_Project"] = _Project;
            return View();
        }
        public async Task<IActionResult> SaveFreelanceRating(FreelanceRating FreelanceRating)
        {
            var _Project = _context.Project.SingleOrDefault(p => p.Project_ID == FreelanceRating.Project_ID);
            _Project.SuccessStatus = true;
            var Employer_ID = HttpContext.Session.GetInt32("Employer_ID");
            FreelanceRating.Employer_ID = Employer_ID;
            FreelanceRating.Date_Create = DateTime.Now;
            _context.Update(_Project);
            _context.FreelanceRating.Add(FreelanceRating);
            await _context.SaveChangesAsync();

            /////FreelanceRating
            var _Rating = _context.FreelanceRating.Where(r => r.Freelance_ID == FreelanceRating.Freelance_ID).ToArray();
            var Length = _Rating.Length;
            int sum = 0;
            foreach (var _Ratings in _Rating)
            {
                sum = sum + _Ratings.Score;
            }
            int RatingFree = sum / Length;
            var Freelancedata = _context.Freelance.SingleOrDefault(e => e.Freelance_ID == FreelanceRating.Freelance_ID);
            Freelancedata.Rating = RatingFree;
            _context.Update(Freelancedata);
            await _context.SaveChangesAsync();
            return Json(new { result = FreelanceRating });
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
        public IActionResult TimersPro()
        {
            //2018 - 08 - 20 19:10:36.4797097
            DateTime xxx = new DateTime(2018, 08, 20);
            var ProjectList = _context.Project.Where(p => p.ProjectStatus != false && p.DelStatus != true && p.Freelance_ID == null).ToArray();
            foreach (Project ProjectLists in ProjectList)
            {
                if (ProjectLists.ProjectTimeOut <= DateTime.Now)
                {
                    ProjectLists.ProjectStatus = false;
                }
                _context.Update(ProjectLists);
                _context.SaveChanges();
            }
            var ProjectListD = _context.Project.Where(p => p.DelStatus != true).ToArray();
            var DateTimeNow = DateTime.Now;
            //var day = day.day(); 
            foreach (Project ProjectLists in ProjectListD)
            {
                if (ProjectLists.ProjectTimeOut <= DateTime.Now)
                {
                    ProjectLists.ProjectAuctionStatus = true;
                }
                _context.Update(ProjectLists);
                _context.SaveChanges();
            }
            return Json("OK");
        }
        public async Task<IActionResult> SearchFreelanceAPITest(string Name, int[] Skill)
        {
            var _Freelance = from m in _context.Freelance
                             select m;
            var FreelanceList = new List<FreelanceSkill>();
            if (Name != null && Skill.Length == 0)
            {
                if (!String.IsNullOrEmpty(Name))
                {
                    _Freelance = _Freelance.Where(s => s.FullName.Contains(Name) && s.DelStatus == false);
                }
            }
            else if (Name == null && Skill.Length != 0)
            {
                if (Skill.Length == 1)
                {
                    var FreelanceFromSkill = _context.FreelanceSkill.Where(f => f.Skill_ID == Skill[0])
               .Include(f => f.Freelance).ToList();
                    FreelanceList = FreelanceFromSkill;
                    return Json(new { FreelanceList = FreelanceList });
                }
                if (Skill.Length == 2)
                {
                    var FreelanceFromSkill = _context.FreelanceSkill.Where(f => f.Skill_ID == Skill[0] | f.Skill_ID == Skill[1])
               .Include(f => f.Freelance).ToList();
                    FreelanceList = FreelanceFromSkill;
                    return Json(new { FreelanceList = FreelanceList });
                }
                if (Skill.Length == 3)
                {
                    var FreelanceFromSkill = _context.FreelanceSkill.Where(f => f.Skill_ID == Skill[0] | f.Skill_ID == Skill[1] | f.Skill_ID == Skill[2])
               .Include(f => f.Freelance).ToList();
                    FreelanceList = FreelanceFromSkill;
                    return Json(new { FreelanceList = FreelanceList });
                }

            }
            else if (Name != null && Skill.Length != 0)
            {
                if (Skill.Length == 1)
                {
                    var FreelanceFromSkill = _context.FreelanceSkill.Where(f => f.Skill_ID == Skill[0])
               .Include(f => f.Freelance).ToList();
                    FreelanceList = FreelanceFromSkill;
                    return Json(new { FreelanceList = FreelanceList });
                }
            }
            ViewData["_Freelance"] = await _Freelance.ToListAsync();
            return Json(await _Freelance.ToListAsync());
        }
        public IActionResult SearchFreelanceAPI(int[] Skill)
        {
            var FreelanceList = new List<Freelance>();
            if (Skill.Length == 1)
            {
                int Skill1 = Skill[0];
                var FreelanceFromSkill = _context.Freelance
            .Include(f => f.FreelanceSkill)
                .ThenInclude(f => f.Skill)
            .Where(f => f.FreelanceSkill.Any(fs => fs.Skill_ID == Skill1))
                .ToList();
                FreelanceList = FreelanceFromSkill;
            }
            if (Skill.Length == 2)
            {
                int Skill21 = Skill[0];
                int Skill22 = Skill[1];
                var FreelanceFromSkill = _context.Freelance
            .Include(f => f.FreelanceSkill)
                .ThenInclude(f => f.Skill)
            .Where(f => f.FreelanceSkill.Any(fs => fs.Skill_ID == Skill21 || fs.Skill_ID == Skill22))
                .ToList();
                FreelanceList = FreelanceFromSkill;
            }
            if (Skill.Length == 3)
            {
                int Skill31 = Skill[0];
                int Skill32 = Skill[1];
                int Skill33 = Skill[2];
                var FreelanceFromSkill = _context.Freelance
            .Include(f => f.FreelanceSkill)
                .ThenInclude(f => f.Skill)
            .Where(f => f.FreelanceSkill.Any(fs => fs.Skill_ID == Skill31 || fs.Skill_ID == Skill32 || fs.Skill_ID == Skill33))
                .ToList();
                FreelanceList = FreelanceFromSkill;
            }
            return Json(FreelanceList);
        }
        public IActionResult dddd()
        {
            var Freelance = _context.FreelanceSkill.Where(f => f.Skill_ID == 1)
            .Include(s => s.Freelance)
            .ToList();
            var Freelance_ = new Freelance();
            foreach (var item in Freelance)
            {
                Freelance_ = _context.Freelance.SingleOrDefault(f => f.Freelance_ID == item.Freelance.Freelance_ID);
                _context.Entry(Freelance_)
                .Collection(b => b.FreelanceSkill)
                .Load();
                foreach (var item1 in Freelance_.FreelanceSkill)
                {
                    _context.Entry(item1)
                    .Reference(b => b.Skill)
                    .Load();
                }
            }
            return Json(Freelance_);
        }
        public IActionResult GetFreelance()
        {
            var freelance = _context.Freelance
            .Include(f => f.FreelanceSkill)
                .ThenInclude(f => f.Skill)
            .Where(f => f.FreelanceSkill.Any(fs => fs.Skill_ID == 1))
                .ToList();
            return Json(freelance);
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
