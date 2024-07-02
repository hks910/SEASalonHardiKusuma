
using SEASalon.Model;
using SEASalon.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SEALevel1.Views
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }
            else // Jika Ada Cookie
            {
                //Ini klo misalnya ada cookienya, tp sessionnya null
                User user;
                if (Session["user"] == null)
                {
                    var id = Convert.ToInt32(Request.Cookies["user_cookie"].Value);
                    UserRepository userRepository = new UserRepository();
                    user = userRepository.GetUserById(id);
                    Session["user"] = user;
                }
                else
                {
                    // kalau sessionnya tidak null
                    user = (User)Session["user"];
                }

                if (user.UserRole == "Admin")
                {
                    AdminNavbar.Visible = true;
                    CustomerNavbar.Visible = false;
            

                }
                else if (user.UserRole == "Customer")
                {
                    AdminNavbar.Visible = false;
                    CustomerNavbar.Visible = true;
               
                }
                else if (user.UserRole == "Guest") // Klo Guest ...
                {
                    Response.Redirect("~/Views/LoginPage.aspx");
                }

            }
        }
    }
}