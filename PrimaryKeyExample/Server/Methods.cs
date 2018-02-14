using PrimaryKeyExample.Context;
using PrimaryKeyExample.Models;
using PrimaryKeyExample.Models.Transactions;
using PrimaryKeyExample.Models.UserTransactions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebMatrix.WebData;
using AutoMapper;

namespace PrimaryKeyExample.Server
{
    public class Methods
    {
        private DatabaseContext database = new DatabaseContext();
        
        public void Add(int UserId, string Name, string MobileNumber, string UserName, string Password, long AadharNum)
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
            var Displayall =(database.NewUSers).AsNoTracking().ToList();
            return Displayall;
        }
        public NewUserEdit DisplayDetails(int UserId)
        {
            NewUserEdit newUser = (database.NewUSers.Where(m=>m.UserId == UserId)).FirstOrDefault();
            return newUser;
        }
        public bool Check(string MobileNumber)
        {
            var temp = /*database.NewUSers.Where(m=>m.MobileNumber == MobileNumber);*/ database.NewUSers.AsNoTracking().Any(m => m.MobileNumber.Equals( MobileNumber));
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
            bool exist = check.Any(m => m.MobileNumber.Equals( Number));
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

        public void Delete(NewUserEdit newUserEdit)
        {
            try
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    db.NewUSers.Remove(newUserEdit);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {

            }
            
        }

        public bool ValidateMobileNumber(string Number)
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
        public void EditDetails(int UserId,NewUserEdit newUser)
        {
            try
            {
                //using(DatabaseContext db = new DatabaseContext())
                //{
                //    try
                //    {
                //        var Name = new SqlParameter("@Name", newUserEdit.Name);
                //        var AadharNumber = new SqlParameter("@AadharNumber" ,newUserEdit.Aadharnum);
                //        var MobileNumber = new SqlParameter("@MobileNumber", newUserEdit.MobileNumber);
                //        var UserID = new SqlParameter("@UserId", UserId);
                //        AadharNumber.SqlDbType = System.Data.SqlDbType.BigInt;
                //        Name.SqlDbType = System.Data.SqlDbType.NVarChar;
                //        MobileNumber.SqlDbType = System.Data.SqlDbType.BigInt;
                //        UserID.SqlDbType = System.Data.SqlDbType.Int;
                //        Object[] temp = new object[4];
                //        temp[1] = Name;
                //        temp[2] = AadharNumber;
                //        temp[3] = MobileNumber;
                //        temp[0] = UserID;
                //        //SqlParameter[] sql = new SqlParameter[1]
                //        //{
                //        //}
                //        //db.Database.ExecuteSqlCommand("update NewUserEdits set Name = {1} ,AadharNum = {2} ,MobileNum = {3} where UserId = {0}",temp);

                //            var check = db.Database.SqlQuery<NewUserEdit>("exec spUpdateDetails @UserId , @Name , @AadharNumber , @MobileNumber", temp);
                //        db.SaveChanges();
                //    }
                //    catch(Exception e)
                //    {

                //    }
                //}
                if (ValidateMobileNumber(newUser.MobileNumber))
                {
                    using (DatabaseContext db = new DatabaseContext())
                    {
                        NewUserEdit data = (from x in db.NewUSers
                                            where x.UserId == UserId
                                            select x).First();
                        data.UserName = "temppassq";
                        data.Password = "Passwordq";
                        //data.NewUserId = newUserEdit.NewUserId;
                        //data.UserId = newUserEdit.UserId;
                        data.Name = newUser.Name;
                        data.MobileNumber = newUser.MobileNumber;
                        data.Aadharnum = newUser.Aadharnum;
                        //NewUserEdit newUserEdit1 = database.NewUSers.Find(UserId);
                        //newUserEdit.UserName = "Hello";
                        //newUserEdit.Password = "Password1234";
                        //database.Entry(newUserEdit).State = System.Data.Entity.EntityState.Modified;
                        //db.Entry(newUser).CurrentValues.SetValues(data);
                        db.Entry(data).State = EntityState.Modified;
                        //db.NewUSers.Attach(data);
                        db.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("Mobile Number is Invalid");
                }
            }
            catch (Exception e)
            {

            }
        }

        public bool UserExists(string userName)
        {
            try
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    bool check = db.NewUSers.AsNoTracking().Any(m => m.UserName == userName);
                    if (check)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public NewUserEdit Find(int id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                NewUserEdit newUserEdit = db.NewUSers.Find(id);
                return newUserEdit;
            }
        }
        public void GuesLogin(GuestLogin guest)
        {
            try
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    db.Guests.Add(guest);
                    db.SaveChanges();
                }
            }
            catch(Exception e)
            {

            }
        }
    }
}