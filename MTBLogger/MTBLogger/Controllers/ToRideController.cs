using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTBLogger.Data;
using MTBLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTBLogger.Controllers
{
    public class ToRideController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ToRideController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET - Create
        public IActionResult Create()
        {
            return View();
        }

        // POST - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
       public IActionResult Create(ToRide obj)
        {
            if(ModelState.IsValid)
            {
                obj.UserId = HttpContext.Session.GetInt32("UserId");
                _db.ToRide.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Create");
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

            var obj = _db.ToRide.Find(id);

            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ToRide obj)
        {
            if(ModelState.IsValid)
            {
                obj.UserId = HttpContext.Session.GetInt32("UserId");
                _db.ToRide.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(obj);
        }

        // GET - Delete
        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _db.ToRide.Find(id);

            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST - Delete
        public IActionResult DeletePost(ToRide obj)
        {
            if(obj == null)
            {
                return NotFound();
            }

            _db.ToRide.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
