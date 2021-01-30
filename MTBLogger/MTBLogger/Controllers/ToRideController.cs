using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTBLogger.Controllers
{
    public class ToRideController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
