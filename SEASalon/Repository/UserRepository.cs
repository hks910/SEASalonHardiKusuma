using SEASalon.Factory;
using SEASalon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEASalon.Repository
{
    public class UserRepository
    {

        Database1Entities2 db = DatabaseSingleton.getInstance();
        public void CreateUser(string fullName, string email, string phoneNumber, string password)
        {
            User user = UserFactory.Create(fullName, email, phoneNumber, password);
            db.Users.Add(user);
            db.SaveChanges();

        }

        public User GetUserByPhoneNumber(string phoneNumber)
        {
            return (from x in db.Users where x.UserPhone.Equals(phoneNumber) select x).FirstOrDefault();
        }

        public int GetUserId(string phoneNumber)
        {
            return (from x in db.Users where x.UserPhone.Equals(phoneNumber) select x.UserId).FirstOrDefault();
        }


        public User GetUserById(int id)
        {
            return (from x in db.Users where x.UserId.Equals(id) select x).FirstOrDefault();
        }
    }
}