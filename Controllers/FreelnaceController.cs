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
        public async Task<IActionResult> SearchString(string searchString = "โคราช")
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
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
