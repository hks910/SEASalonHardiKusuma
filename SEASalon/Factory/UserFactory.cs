using SEASalon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEASalon.Factory
{
    public class UserFactory
    {
        public static User Create(string fullName, string userEmail, string userPhoneNumber, string userPassword)
        {
            User user = new User();

            user.FullName = fullName;
            user.UserEmail = userEmail;
            user.UserPhone = userPhoneNumber;
            user.UserPassword = userPassword;
            user.UserRole = "Customer";

            return user;
        }
    }
}