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

namespace PrimaryKeyExample.Controllers
{
    public class AdminController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        Methods methods = new Methods();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DisplayAll()
        {
            return View(methods.DisplayAll());
        }
        public ActionResult Edit(int id)
        {
            //var data = db.NewUSers.Find(id);
            var Details = (db.NewUSers.Where(m => m.UserId == id).Select(m => new
            {
                NewUserId = m.NewUserId,
                Name = m.Name,
                MobileNumber = m.MobileNumber,
                Aadharnum = m.Aadharnum
            })).ToList();
            return View(Details);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NewUsersEdit userDetails)
        {
            //if (ModelState.IsValid)
            //{
            try
            {
                NewUser newUser = new NewUser();
                newUser.Name = userDetails.Name;
                newUser.MobileNumber = userDetails.MobileNumber;
                newUser.Aadharnum = userDetails.Aadharnum;
                db.Entry(newUser).State = EntityState.Modified;
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
    }
}