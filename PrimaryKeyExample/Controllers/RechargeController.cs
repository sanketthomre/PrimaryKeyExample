using PrimaryKeyExample.Context;
using PrimaryKeyExample.Models.Transactions;
using PrimaryKeyExample.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrimaryKeyExample.Controllers
{
    public class RechargeController : Controller
    {
        Methods methods = new Methods();
        // GET: Recharge
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Recharge()
        {
            ViewBag.Operators = new List<SelectListItem>()
           {
               new SelectListItem {Text = "Vodafone",Value = "Vodafone"},
               new SelectListItem {Text = "Docomo" , Value = "Docomo"},
               new SelectListItem {Text = "Bsnl",Value = "Bsnl"},
               new SelectListItem {Text = "Jio",Value = "Jio"}
           };
            return View();
        }
        [HttpPost]
        public ActionResult Recharge(Recharge recharge)
        {  
            try
            {
                Transaction transaction = new Transaction
                {
                    DateOfTransation = DateTime.Now,
                    Status = true,
                    ErrorMessage = "Success"
                };
                methods.SaveTransactions(transaction,recharge);
                return RedirectToAction("Welcome", "NewUserRegister");
            }
            catch (Exception e)
            {
                Transaction transaction = new Transaction
                {
                    Status = false,
                    ErrorMessage = e.Message,
                    DateOfTransation = DateTime.Now,                   
                };
                methods.SaveTransactions(transaction, recharge);
                ModelState.AddModelError("", "Error" + e.Message);
                return View();
            }
        }
    }
}