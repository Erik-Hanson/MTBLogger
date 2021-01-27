using Microsoft.AspNetCore.Mvc;
using MTBLogger.Data;
using MTBLogger.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTBLogger.Controllers
{
    public class LoggedController : Controller
    {
        private readonly ApplicationDbContext _db;

        public LoggedController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET - Log
        public IActionResult Log()
        {
            return View();
        }

        // POST - Log
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Log(Logged obj)
        {
            Console.WriteLine(HttpContext.Session.GetInt32("UserId"));

            if (ModelState.IsValid)
            {
                obj.UserId = HttpContext.Session.GetInt32("UserId");
                _db.Logged.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(obj);
        }
    }
}
