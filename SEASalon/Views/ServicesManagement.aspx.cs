using SEASalon.Model;
using SEASalon.Repository;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SEASalon.Views
{
    public partial class AddServices : System.Web.UI.Page
    {
        public int UserId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Any initial setup code here
            }

            if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }
            else
            {
                User user;
                if (Session["user"] == null)
                {
                    var id = Convert.ToInt32(Request.Cookies["user_cookie"].Value);
                    UserRepository userRepository = new UserRepository();
                    user = userRepository.GetUserById(id);
                    Session["user"] = user;
                    UserId = user.UserId;
                }
                else
                {
                    user = (User)Session["user"];
                    UserId = user.UserId;
                }

                if (user.UserRole != "Admin")
                {
                   
                    Response.Redirect("~/Views/home.aspx");
                }
          
                serviceRepository serviceRepository = new serviceRepository();
                List<Service> service = serviceRepository.getAllService();
                ServiceList.DataSource = service;
                ServiceList.DataBind();


            }

        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            string serviceName = ServiceNameTxt.Text.Trim();
            string serviceDurationText = ServiceDurationTxt.Text.Trim();

            // Validate input
            string errorMessage = ValidateInput(serviceName, serviceDurationText);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                ErrorLbl.Text = errorMessage;
                return;
            }

    
            int serviceDuration = int.Parse(serviceDurationText);

         
            serviceRepository serviceRepository = new serviceRepository();
            serviceRepository.CreateService(serviceName, serviceDuration);

            // Clear form and show success message
            ClearForm();
            ErrorLbl.Text = "Service added successfully!";
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        private string ValidateInput(string serviceName, string serviceDurationText)
        {
            if (string.IsNullOrEmpty(serviceName))
            {
                return "Service name is required.";
            }

            if (string.IsNullOrEmpty(serviceDurationText) || !int.TryParse(serviceDurationText, out _))
            {
                return "Valid service duration is required.";
            }

            return string.Empty;
        }

        private void ClearForm()
        {
            ServiceNameTxt.Text = string.Empty;
            ServiceDurationTxt.Text = string.Empty;
        }


        protected void ServiceList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument); // Get the row index

                // Get the ServiceId from the GridView data keys
                int serviceId = Convert.ToInt32(ServiceList.DataKeys[rowIndex].Value);

                // Perform deletion logic (replace this with your actual delete code)
                serviceRepository serviceRepository = new serviceRepository();
                serviceRepository.DeleteService(serviceId);

                // Refresh the GridView after deletion
                BindGridView(); // Call a method to rebind your GridView data

                // Optionally, show a success message
                ErrorLbl.Text = "Service deleted successfully!";
            }
        }

        private void BindGridView()
        {
            // Re-bind your GridView data here
            serviceRepository serviceRepository = new serviceRepository();
            List<Service> services = serviceRepository.getAllService();
            ServiceList.DataSource = services;
            ServiceList.DataBind();
        }



    }
}