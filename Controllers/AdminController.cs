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
            return View();
        }
        public IActionResult Login()
        {

            return View();
        }
        public IActionResult Dashboard()
        {

            return View();
        }
        public IActionResult RegisterAdmin(Admin Admin)
        {
            Admin.UserName = "adminGo";
            Admin.PassWord = "123qwe";
            Admin.DelStatus = false;
            Admin.Date_Create = DateTime.Now;
            Admin.Date_Update = DateTime.Now;
            _context.Add(Admin);
            _context.SaveChanges();
            return Json("Register-OK////");
        }
        public IActionResult LoginAdmin(Admin Admin)
        {
            var loginde = _context.Admin
                .Single(f => f.UserName == Admin.UserName && f.PassWord == Admin.PassWord);
            HttpContext.Session.SetInt32("Admin_ID", loginde.Admin_ID);
            ViewData["Admin_ID"] = loginde.Admin_ID;
            return Json(new { Result = loginde });
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
