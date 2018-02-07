using PrimaryKeyExample.Context;
using PrimaryKeyExample.Models;
using PrimaryKeyExample.Models.Admin_Controlls;
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
            if (Session["UserName"] == null)
            {
                return View();
            }
            else
            {
                RedirectToAction("Welcome");
            }
            return View();

        }
        [HttpPost]
        public ActionResult NewUser(NewUserEdit newUser)
        {
            if (Session["UserName"] == null)
            {

                if (ModelState.IsValid && !WebSecurity.UserExists(newUser.UserName))
                {
                    if (methods.Check(newUser.MobileNumber))
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
                        ModelState.AddModelError("", "Number Already Exists");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User Already Exists");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("","Already Logged in as" + Session["UserName"]);
                return View();
            }

        } //End of NewUser Method note

        [HttpGet]
        public ActionResult Login()
        {
            if (Session["UserName"] == null)
            {
                return View();
            }
            else
            {
               return RedirectToAction("Welcome","NewUserRegister");
            }
            //return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
            if(ModelState.IsValid && WebSecurity.UserExists(login.UserName))
            {
                try
                {
                    WebSecurity.Login(login.UserName, login.Password);
                    Session["UserName"] = login.UserName;
                    return RedirectToAction("Welcome");
                }
                catch(Exception e)
                {
                    ModelState.AddModelError("", "Somethings Wiered Happened. Pls try again later" + e.Message);
                    return View();
                }
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
        public ActionResult Users(NewUserEdit newUser)
        {
            var UserID = WebSecurity.GetUserId(newUser.UserName);
            string UserName = methods.AllUser(UserID);
            return View(UserName);
        }
        [HttpGet]
        public ActionResult Welcome()
        {
            ViewBag.Username = Session["UserName"];
            return View();
        }
        [HttpPost]
        public ActionResult Welcome(NewUserEdit newUser)
        {
            if (Session["UserName"] != null)
            {
                ViewBag.Username = Session["UserName"];
                return View(newUser);
            }
            else
            {

                return View();
            }
        }
        public ActionResult DisplayAll()
        {
            return View(methods.DisplayAll());
        }
        [HttpGet]
        public ActionResult DisplayDetails(NewUserEdit newUser)
        {
            if (Session["UserName"] != null)
            {
                var UserID = WebSecurity.GetUserId(Session["UserName"].ToString());
                newUser = methods.DisplayDetails(UserID);
                return View(newUser);
            }
            else
            {
                ModelState.AddModelError("", "Please Login to Display Your Details");
                return RedirectToAction("Login");
            }
        }
        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(EditNewUser EditNewUser)
        {
            DatabaseContext databaseContext = new DatabaseContext();
            var UserId = WebSecurity.GetUserId(Session["UserName"].ToString());
            NewUserEdit newUser = databaseContext.NewUSers.Find(UserId);

            newUser.Name = EditNewUser.Name;
            newUser.MobileNumber = EditNewUser.MobileNumber;
            newUser.Aadharnum = EditNewUser.Aadharnum;
            databaseContext.SaveChanges();
            return View(newUser);
        }
        
    }
}