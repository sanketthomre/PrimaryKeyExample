using PrimaryKeyExample.Context;
using PrimaryKeyExample.Models;
using PrimaryKeyExample.Models.Transactions;
using PrimaryKeyExample.Models.UserTransactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.WebData;

namespace PrimaryKeyExample.Server
{
    public class Methods
    {
        private DatabaseContext database = new DatabaseContext();
        public void Add(int UserId, string Name, long MobileNumber, string UserName, string Password, long AadharNum)
        {
            NewUserEdit NewUsers = new NewUserEdit()
            {
                UserId = UserId,
                Name = Name,
                MobileNumber = MobileNumber,
                UserName = UserName,
                Password = Password,
                Aadharnum = AadharNum
            };
            database.NewUSers.Add(NewUsers);
            database.SaveChanges();
        }
        public string AllUser(int userId)
        {
            var result = from data in database.NewUSers
                         where data.UserId == userId
                         select data.Name;
            return (result.ToString());
        }
        public List<NewUserEdit> DisplayAll()
        {
            var Displayall =(database.NewUSers).ToList();
            return Displayall;
        }
        public NewUserEdit DisplayDetails(int UserId)
        {
            NewUserEdit newUser = database.NewUSers.Find(UserId);
            return newUser;
        }
        public bool Check(long MobileNumber)
        {
            bool temp = database.NewUSers.AsNoTracking().Any(m => m.MobileNumber == MobileNumber);
            if (temp)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void SaveTransactions(Transaction transaction, Recharge recharge,int UserId)
        {
            recharge.UserID = UserId;
            database.Transaction.Add(transaction);
            database.Recharge.Add(recharge);
            database.SaveChanges();
        }
        public bool MobileNumberExists(long Number)
        {
            var check = database.Recharge.ToList();
            bool exist = check.Any(m => m.MobileNumber == Number);
            var temp = Number.ToString();
                if (exist)
                    return true;
                else
                    return false;
        }
        public bool TransactionExists(int UserId)
        {
            bool Check = database.Recharge.AsNoTracking().Any(m => m.UserID == UserId);
            if (Check)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ValidateMobileNumber(long Number)
        {
            var temp = Number.ToString();
            if (temp.Length == 10)
            {
                return true;
            }
            else
                return false;
        }
        public List<UserTransactions> UserTransaction(int UserID)
        {

            IEnumerable<Recharge> recharge = (database.Recharge.Where(r => r.UserID == UserID)).ToList();
            IEnumerable<Transaction> transaction = database.Transaction.ToList();
            var DisplayData = (from r in recharge
                               join t in transaction on r.RechargeID equals t.RechargeID
                               orderby r.Amount
                              select new UserTransactions()
                              {
                                  MobileNumber = r.MobileNumber,
                                  TransactionId = t.TransationID,
                                  Amount = r.Amount,
                                  Status = t.Status
                              }).ToList();
            return DisplayData;
        }

        //public string Find(string id)
        //{
        //    return WebSecurity.GetUserId();
        //}
    }
}