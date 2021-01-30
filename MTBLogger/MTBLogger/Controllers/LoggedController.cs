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
            if (ModelState.IsValid)
            {
                obj.UserId = HttpContext.Session.GetInt32("UserId");
                _db.Logged.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(obj);
        }

        // GET - Edit
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _db.Logged.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Logged obj)
        {
            if (ModelState.IsValid)
            {
                obj.UserId = HttpContext.Session.GetInt32("UserId");
                _db.Logged.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(obj);
        }

        // GET - Delete
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _db.Logged.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST - Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(Logged obj)
        {
            //var obj = _db.Logged.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _db.Logged.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
