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
      public IActionResult HandelLogin( string email , string password)
        {
            string email1 = HttpContext.Session.GetString("email");
            string password1 = HttpContext.Session.GetString("password");


            //if (email1 == "sara@gmail.com" && password1 == "123")

            //{
            //    return RedirectToAction("Index", "Home");
            //}
            //else
            //{

            //    return RedirectToAction("Login");
            //}

            

           
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




        public IActionResult Profile()
        {
            return View();
        }
    }
}
