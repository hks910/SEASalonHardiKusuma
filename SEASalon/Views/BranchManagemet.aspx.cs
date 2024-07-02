using SEASalon.Model;
using SEASalon.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SEASalon.Views
{
    public partial class BranchManagemet : System.Web.UI.Page
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

                // Load branches into the GridView
                BindBranchGridView();
            }
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            string branchNameText = BranchNameTxt.Text;
            string branchLocation = BranchLocationTxt.Text;
            TimeSpan openingTime;
            TimeSpan closingTime;

            // Attempt to parse the opening time
            if (!TimeSpan.TryParseExact(OpeningTimeTxt.Text.Trim(), "HH:mm", CultureInfo.InvariantCulture, out openingTime))
            {
                ErrorLbl.Text = "Error: Invalid opening time format. Please enter time in HH:mm format.";
                return;
            }

            // Attempt to parse the closing time
            if (!TimeSpan.TryParseExact(ClosingTimeTxt.Text.Trim(), "HH:mm", CultureInfo.InvariantCulture, out closingTime))
            {
                ErrorLbl.Text = "Error: Invalid closing time format. Please enter time in HH:mm format.";
                return;
            }

            // Add branch to repository
            BranchRepository branchRepository = new BranchRepository();
            branchRepository.addBranch(branchNameText, branchLocation, openingTime, closingTime);

            // Clear form and show success message
            ClearForm();
   

            // Refresh the GridView after adding branch
            BindBranchGridView();
        }

        private void ClearForm()
        {
            BranchNameTxt.Text = string.Empty;
            BranchLocationTxt.Text = string.Empty;
            OpeningTimeTxt.Text = string.Empty;
            ClosingTimeTxt.Text = string.Empty;
        }

        private void BindBranchGridView()
        {
            // Load branches into the GridView
            BranchRepository branchRepository = new BranchRepository();
            List<Branch> branches = branchRepository.GetBranches();
            BranchList.DataSource = branches;
            BranchList.DataBind();
        }

        protected void BranchList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument); // Get the row index

                // Get the BranchId from the GridView data keys
                int branchId = Convert.ToInt32(BranchList.DataKeys[rowIndex].Value);

                // Perform deletion logic
                BranchRepository branchRepository = new BranchRepository();
                branchRepository.deleteBranch(branchId);

                // Refresh the GridView after deletion
                BindBranchGridView();

                // Optionally, show a success message
                ErrorLbl.Text = "Branch deleted successfully!";
            }
        }
    }
}
