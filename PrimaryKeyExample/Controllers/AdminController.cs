using PrimaryKeyExample.Context;
using PrimaryKeyExample.Models;
using PrimaryKeyExample.Models.Admin_Controlls;
using PrimaryKeyExample.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace PrimaryKeyExample.Controllers
{
    public class AdminController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        Methods methods = new Methods();
        // GET: Admin
        public ActionResult Index()
        {
            return PartialView("_HomePage");
        }
        public ActionResult DisplayAll()
        {
            return View(methods.DisplayAll());
        }
        public ActionResult Edit(int?id)
        {
            NewUserEdit data = db.NewUSers.Find(id);
            return View(data);
            //return RedirectToAction("Edit", "NewUserRegister");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="Name,AadharNum,MobileNumber")]NewUserEdit data)
        {
            try
            {               
                data.Password = "TempPassword";
                data.UserName = "TempUserName";
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DisplayAll");
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            //}
            //return View(userDetails);
        }
        public ActionResult Details(int? id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                NewUserEdit newUserEdit = db.NewUSers.Find(id);
                return View(newUserEdit);
            }
            
        }
        public ActionResult Delete()
        {
            return View();
        }
        public ActionResult Delete(NewUserEdit newUserEdit)
        {
            var userId = WebSecurity.GetUserId(Session["UserName"].ToString());
            try
            {
                newUserEdit = methods.Find(userId);
                methods.Delete(newUserEdit);
                Session["UserName"] = null;
                return RedirectToAction("Index", "Home");

            }
            catch(Exception e)
            {
                ModelState.AddModelError("", "Cannot Delete ");
                return View();
            }
            
        }
    }
}