using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTBLogger.Data;
using MTBLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MTBLogger.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET - Register
        public IActionResult Register()
        {
            return View();
        }

        // POST - Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User obj)
        {
            if(ModelState.IsValid)
            {
                obj.Password = GetMD5(obj.Password);
                _db.User.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(obj); 
        }

        // GET - Login
        public IActionResult Login()
        {
            return View();
        }

        // POST - Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string password)
        {
            if(ModelState.IsValid)
            {
                var pass = GetMD5(password);
                var data = _db.User.Where(s => s.Email.Equals(email) && s.Password.Equals(pass)).ToList();

                if(data.Count > 0)
                {
                    HttpContext.Session.SetString("FullName", data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName);
                    HttpContext.Session.SetString("Email", data.FirstOrDefault().Email);
                    HttpContext.Session.SetInt32("UserId", data.FirstOrDefault().UserId);
                    return RedirectToAction("Index", "Home");
                } 
                else
                {
                    ModelState.AddModelError("Email", "Incorrect login credentials/account does not exist");
                    return View();
                }
            }
            return View();
        }

        // GET - Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string hashString = null;

            for(int ndx = 0; ndx < targetData.Length; ndx++)
            {
                hashString += targetData[ndx].ToString("x2"); // format as hexadecimal
            }

            return hashString;
        }
    }
}
