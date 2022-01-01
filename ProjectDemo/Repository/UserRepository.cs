using ProjectDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectDemo.Repository
{
    public class UserRepository
    {
        UserDb bd = new UserDb();
        public bool AddUser(User user1)
        {
            bd.Users.Add(user1);
            bd.SaveChanges();
            return true;

        }
    }
}