using SEASalon.Model;
using SEASalon.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEASalon.Handler
{
    public class RegisterHandler
    {
        private UserRepository userRepository = new UserRepository();

        public string RegisterUser(string name, string email, string phoneNumber, string password)
        {
            var phoneNumberse = userRepository.GetUserByPhoneNumber(phoneNumber);
            if (phoneNumberse != null)
            {
                return "Phone Number already used, use other number!";
            }


            userRepository.CreateUser(name, email, phoneNumber, password);

            return "Successfully Registered";

        }
    }
}
