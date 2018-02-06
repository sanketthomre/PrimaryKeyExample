using ProjectRecharge.Models.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectRecharge.Controllers
{
    public class RechargeController : Controller
    {
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
               new SelectListItem { Text = "Vodafone",Value = "1"},
               new SelectListItem {Text = "Docomo" , Value = "2"}
           };
            return View();
        }
        [HttpPost]
        public ActionResult Recharge(Recharge recharge)
        {
            Transaction transaction = new Transaction();
            try
            {
                transaction.RechargeID = recharge.RechargeID;
                transaction.DateOfTransation = DateTime.Now;
                transaction.Status = true;
                return View("TransactionCompleted");
            }
            catch(Exception e)
            {
                transaction.Status = false;
                ModelState.AddModelError("", "Error" + e.Message);
                return View();
            }
        }
    }
}