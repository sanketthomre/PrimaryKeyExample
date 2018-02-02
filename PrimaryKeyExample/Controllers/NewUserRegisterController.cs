using PrimaryKeyExample.Models;
using PrimaryKeyExample.Server;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace PrimaryKeyExample.Controllers
{
    public class NewUserRegisterController : Controller
    {
        Methods methods = new Methods();
        // GET: NewUserRegister
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult NewUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewUser(NewUser newUser)
        {
            if (ModelState.IsValid && !WebSecurity.UserExists(newUser.UserName))
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(newUser.UserName, newUser.Password);
                    var UserId = WebSecurity.GetUserId(newUser.UserName);
                    methods.Add(UserId, newUser.Name, newUser.MobileNumber, newUser.UserName, newUser.Password, newUser.Aadharnum);
                    return RedirectToAction("Login");
                }
                catch (Exception e)
                {

                    ModelState.AddModelError("", "SomeThing weird happend.. Try again later" + e.Message);
                    return View();
                }

            }
            else
            {
                ModelState.AddModelError("", "User Already Exists");
                return View();
            }

        } //End of NewUser Method
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
            if(ModelState.IsValid && WebSecurity.UserExists(login.UserName))
            {
                WebSecurity.Login(login.UserName, login.Password);
                return RedirectToAction("Welcome");
            }
            else
            {
                ModelState.AddModelError("", "Invalid Credentials");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Users()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Users(NewUser newUser)
        {
            var UserID = WebSecurity.GetUserId(newUser.UserName);
            string UserName = methods.AllUser(UserID);
            return View(UserName);
        }
    }
}