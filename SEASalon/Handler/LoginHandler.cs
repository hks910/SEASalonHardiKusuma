using SEASalon.Model;
using SEASalon.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEASalon.Handler
{
    public class LoginHandler
    {
        UserRepository userRepository = new UserRepository();

        public string ValidateLogin(string phoneNumber, string password, out User user)
        {


            user = userRepository.GetUserByPhoneNumber(phoneNumber);

            if (user == null)
            {
                return "User not found !!";
            }
            else if (!password.Equals(user.UserPassword))
            {
                return "Wrong Password";
            }

            return string.Empty; // No error
        }

        public int getUserId(string phoneNumber)
        {
            User user = userRepository.GetUserByPhoneNumber(phoneNumber);
            int userId = user.UserId;
            return userId;
        }
    }
}
