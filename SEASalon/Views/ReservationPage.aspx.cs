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
    public partial class ReservationPage : System.Web.UI.Page
    {
        public int UserId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBranches();
                InitializeDropdowns();
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

                LoadReservations(UserId);
            }
        }

        private void LoadBranches()
        {
            BranchRepository branchRepository = new BranchRepository();
            List<Branch> branches = branchRepository.GetBranches();
            BranchList.DataSource = branches;
            BranchList.DataTextField = "BranchName";
            BranchList.DataValueField = "BranchId";
            BranchList.DataBind();
        }

        private void InitializeDropdowns()
        {
            // Add a default item to the dropdowns
            BranchList.Items.Insert(0, new ListItem("Select a Branch", ""));
            ServiceList.Items.Insert(0, new ListItem("Select a Service", ""));
        }

        private void LoadReservations(int userId)
        {
            ReservationRepository reservationRepository = new ReservationRepository();
            List<Reservation> reservations = reservationRepository.GetAllReservationsbyUserId(userId);
            Reservation.DataSource = reservations;
            Reservation.DataBind();
        }

        protected void BranchList_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshCart();
        }

        private void RefreshCart()
        {
            if (!string.IsNullOrEmpty(BranchList.SelectedValue))
            {
                BranchServiceRepository branchServiceRepository = new BranchServiceRepository();
                List<int> serviceIdList = branchServiceRepository.GetServiceList(Convert.ToInt32(BranchList.SelectedValue));
                serviceRepository serviceRepository = new serviceRepository();
                List<Service> services = serviceRepository.getServiceList(serviceIdList);
                ServiceList.DataSource = services;
                ServiceList.DataTextField = "ServiveName";
                ServiceList.DataValueField = "ServiceId";
                ServiceList.DataBind();

                // Add a default item to the ServiceList dropdown
                ServiceList.Items.Insert(0, new ListItem("Select a Service", ""));
            }
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (IsValidReservation())
            {
                int branchId = Convert.ToInt32(BranchList.SelectedValue);
                int serviceId = Convert.ToInt32(ServiceList.SelectedValue);
                DateTime reservationTime = Convert.ToDateTime(timeTxt.Text);

                ReservationRepository reservationRepository = new ReservationRepository();
                reservationRepository.CreateReservation(UserId, serviceId, branchId, reservationTime);

                ErrorLbl.Text = "Reservation submitted successfully!";
                ClearForm();
                RefreshCart();
                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }

        private bool IsValidReservation()
        {
            if (string.IsNullOrEmpty(BranchList.SelectedValue) ||
                string.IsNullOrEmpty(ServiceList.SelectedValue) ||
                string.IsNullOrEmpty(timeTxt.Text))
            {
                ErrorLbl.Text = "All fields are required!";
                return false;
            }
            ErrorLbl.Text = string.Empty;
            return true;
        }

        private void ClearForm()
        {
            BranchList.SelectedValue = null;
            ServiceList.SelectedValue = null;
            timeTxt.Text = string.Empty;
        }
    }
}
