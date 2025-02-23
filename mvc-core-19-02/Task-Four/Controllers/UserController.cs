using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using Task_Four.Models;

namespace Task_Four.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }



        [HttpPost]
        public IActionResult HandelRegister(string name, string email, string password, string RepeatPassword)

        {
            if (RepeatPassword == password)
            {
                HttpContext.Session.SetString("Name", name);
                HttpContext.Session.SetString("Email", email);
                HttpContext.Session.SetString("Password", password);
                return RedirectToAction("Login");
            }
            else
            {
                TempData["Message"] = "Password Does Not Match";
                return RedirectToAction("Register");
            }


        }







        public IActionResult Login()
        {
            return View();
        }




        [HttpPost]
        public IActionResult HandelLogin(string email, string password)
        {


            string email1 = HttpContext.Session.GetString("Email");
            string password1 = HttpContext.Session.GetString("Password");


            if (string.IsNullOrEmpty(email1) || string.IsNullOrEmpty(password1))
            { 

                return RedirectToAction("Login");
    
            }
            else
            {

                if (email1 == "sara@gmail.com" && password1 == "123")

                {
                    return RedirectToAction("Index", "Home");             // admin
                }

                if (email1 == email && password1 == password)
                {
                    //TempData["User"] = new string[] { email, password };
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Message"] = "Wrong email or password!";
                    return RedirectToAction("Login");
                }
              


            }






           
        }
    
      




        public IActionResult Profile()
        {

            ViewData["name"] = HttpContext.Session.GetString("name");

            ViewData["email"] = HttpContext.Session.GetString("email");

            return View();
        }
    }
}
