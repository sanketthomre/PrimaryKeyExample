using PrimaryKeyExample.Context;
using PrimaryKeyExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}