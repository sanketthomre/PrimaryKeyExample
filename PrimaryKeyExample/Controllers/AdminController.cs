using PrimaryKeyExample.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrimaryKeyExample.Controllers
{
    public class AdminController : Controller
    {
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
        public ActionResult Edit()
        {
            return View();
        }
    }
}