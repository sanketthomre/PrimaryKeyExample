using PrimaryKeyExample.Context;
using PrimaryKeyExample.Models.Transactions;
using PrimaryKeyExample.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

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
                var UserId = WebSecurity.GetUserId(Session["UserName"].ToString());
                methods.SaveTransactions(transaction,recharge,UserId);
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
                var UserId = WebSecurity.GetUserId(Session["UserName"].ToString());
                methods.SaveTransactions(transaction, recharge,UserId);
                ModelState.AddModelError("", "Error" + e.Message);
                return View();
            }
        }
        public ActionResult AllTransactions()
        {
            DatabaseContext db = new DatabaseContext();
            List<Transaction> transaction = db.Transaction.ToList();
            List<Recharge> recharge = db.Recharge.ToList();
            var model = (from t in transaction join r in recharge on t.RechargeID equals r.RechargeID orderby r.Amount
                         select new AllTransactions()
                         {
                            UserID = r.UserID,
                            MobileNumber = r.MobileNumber,
                            DateOfTransation = t.DateOfTransation,
                            Amount = r.Amount,
                            Operator = r.Operator,
                            Status = t.Status
                        }).ToList();

            return View(model);
        }
    }
}