
using SEASalon.Controller;
using SEASalon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SEALevel1.Views
{
    public partial class LoginPage : System.Web.UI.Page
    {

        private LoginController controller = new LoginController();

        protected void Page_Load(object sender, EventArgs e)
        {

            ErrorLbl.Text = "";

            // Validate if Login Page only accessible to guests
            if (Session["user"] != null)
            {
                var user = (User)Session["user"];
                if (user.UserRole != "Guest")
                {
                    Response.Redirect("~/Views/home.aspx");
                }

            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {

            string phoneNumber = PhoneNumberTxt.Text;
            string password = PasswordTxt.Text;
            bool isRemember = CheckBoxBtn.Checked;

            User user;
            string error = controller.LoginUser(phoneNumber, password, isRemember, out user);





            if (string.IsNullOrEmpty(error))
            {
                //LoginHandler loginHandler = new LoginHandler();
                //int id = loginHandler.getUserId(username);
                ErrorLbl.ForeColor = System.Drawing.Color.Green;
                //Response.Redirect("~/Views/HomePage.aspx?userID="+id);
                Response.Redirect("~/Views/Home.aspx");
            }
            else
            {
                ErrorLbl.ForeColor = System.Drawing.Color.Red;
                ErrorLbl.Text = error;
            }


        }

        protected void RegisterLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/RegisterPage.aspx");
        }
    }
}