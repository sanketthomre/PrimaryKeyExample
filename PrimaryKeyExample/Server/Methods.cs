using PrimaryKeyExample.Context;
using PrimaryKeyExample.Models;
using PrimaryKeyExample.Models.Transactions;
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
            NewUser NewUsers = new NewUser()
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
        public List<NewUser> DisplayAll()
        {
            var Displayall =(database.NewUSers).ToList();
            return Displayall;
        }
        public NewUser DisplayDetails(int UserId)
        {
            NewUser newUser = database.NewUSers.Find(UserId);
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
        public void SaveTransactions(Transaction transaction, Recharge recharge)
        {
            database.Transaction.Add(transaction);
            database.Recharge.Add(recharge);
            database.SaveChanges();
        }
        //public string Find(string id)
        //{
        //    return WebSecurity.GetUserId();
        //}
    }
}