using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MTBLogger.Data;
using MTBLogger.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MTBLogger.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("FullName") != null) {
                IEnumerable<Logged> obj = _db.Logged.Where(s => s.UserId.Equals(HttpContext.Session.GetInt32("UserId")));
                IEnumerable<ToRide> toRide = _db.ToRide.Where(s => s.UserId.Equals(HttpContext.Session.GetInt32("UserId")));
                Tuple<IEnumerable<Logged>, IEnumerable<ToRide>> tupy = new Tuple<IEnumerable<Logged>, IEnumerable<ToRide>>(obj, toRide);
                return View(tupy);
            } else
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
