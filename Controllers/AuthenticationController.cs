using Event_Mangement.Models;

using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace EventManagement.Controllers
{
    public class AuthenticationController : Controller
    {
        private EventModel dbContext = new EventModel();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var f_password = GetMD5(password);
                var user = dbContext.Users.FirstOrDefault(s => s.Email.Equals(email) && s.Password.Equals(f_password));

                if (user != null)
                {
                    // Add user role or any condition to determine the redirect
                    if (user.Id == 1) 
                    {
                        // Admin user
                        return RedirectToAction("Venues", "Admin");
                    }
                    else
                    {
                        // Customer user
                        return RedirectToAction("Venues", "Customer");
                    }
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(User _user)
        {
            if (ModelState.IsValid)
            {
                var check = dbContext.Users.FirstOrDefault(s => s.Email == _user.Email);
                if (check == null)
                {
                    _user.Password = GetMD5(_user.Password);
                    dbContext.Configuration.ValidateOnSaveEnabled = false;
                    dbContext.Users.Add(_user);
                    dbContext.SaveChanges();

                    // Check the role condition for redirection
                    if (_user.Id == 1) 
                    {
                        // Admin user
                        return RedirectToAction("Venues", "Admin");
                    }
                    else
                    {
                        // Customer user
                        return RedirectToAction("Venues", "Customer");
                    }
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }
            }
            return View();
        }

        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }
        
        public ActionResult Events()
        {
            if (Session["Id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
    }
}
