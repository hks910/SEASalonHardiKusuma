using SEASalon.Handler;
using SEASalon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SEASalon.Controller
{
    public class LoginController
    {


        private LoginHandler handler = new LoginHandler();

        public string LoginUser(string phoneNumber, string password, bool isRemember, out User user)
        {
            user = null;

            // Validate Phone Number and Password
            if (string.IsNullOrEmpty(phoneNumber))
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

            string error = handler.ValidateLogin(phoneNumber, password, out user);

            if (string.IsNullOrEmpty(error) && user != null)
            {
                // Set session and cookies if needed
                HttpContext.Current.Session["user"] = user;

                if (isRemember)
                {
                    HttpCookie cookie = new HttpCookie("user_cookie");
                    cookie.Value = user.UserId.ToString();
                    cookie.Expires = DateTime.Now.AddHours(1);
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }
            }

            return error;
        }
    }
}