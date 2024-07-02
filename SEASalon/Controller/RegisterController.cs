using SEASalon.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SEASalon.Controller
{
    public class RegisterController
    {
        RegisterHandler handler = new RegisterHandler();

        public string RegisterUser(string username, string email, string phoneNumber, string password, string confirmation)
        {
            string errorMessage = ValidateInput(username, email, phoneNumber, password, confirmation);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return errorMessage;
            }

            return handler.RegisterUser(username, email, phoneNumber, password);
        }

        private string ValidateInput(string username, string email, string phoneNumber, string password, string confirmation)
        {
            if (string.IsNullOrEmpty(username))
            {
                return "Fullname cannot be empty!";
            }
            else if (username.Length < 5 || username.Length > 15)
            {
                return "Fullname must be between 5 and 15 characters long!";
            }
            else if (!Regex.IsMatch(username, @"^[a-zA-Z\s]+$"))
            {
                return "Username can only contain alphabets and spaces!";
            }
            else if (string.IsNullOrEmpty(email))
            {
                return "Email cannot be empty!";
            }
            else if (!email.EndsWith(".com"))
            {
                return "Email must end with .com!";
            }
            else if (string.IsNullOrEmpty(phoneNumber))
            {
                return "Phone number cannot be empty!";
            }
            else if (!Regex.IsMatch(phoneNumber, @"^\d+$"))
            {
                return "Phone number must be numeric!";
            }
            else if (phoneNumber.Length < 8 || phoneNumber.Length > 13)
            {
                return "Phone number must be between 8 and 13 characters long!";
            }
            else if (string.IsNullOrEmpty(password))
            {
                return "Password cannot be empty!";
            }
            else if (!Regex.IsMatch(password, @"^[a-zA-Z0-9]+$"))
            {
                return "Password must be alphanumeric!";
            }
            else if (!confirmation.Equals(password))
            {
                return "Password and confirmation do not match!";
            }

            return string.Empty;
        }
    }
}
