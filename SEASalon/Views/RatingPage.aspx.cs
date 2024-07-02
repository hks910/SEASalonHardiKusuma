
using SEASalon.Model;
using SEASalon.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SEALevel1.Views
{
    public partial class RatingPage : System.Web.UI.Page
    {
        public int UserId { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
            if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }
            else
            {
                RatingRepository ratingRepository = new RatingRepository();
                List<Rating> ratings = ratingRepository.GetRatings();
                RatingList.DataSource = ratings;
                RatingList.DataBind();

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
            }

  
        }

        private void RefreshCart()
        {
            RatingRepository ratingRepository = new RatingRepository();
            List<Rating> ratings = ratingRepository.GetRatings();
            RatingList.DataSource = ratings;
            RatingList.DataBind();
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            string customerName = FullNameTxt.Text.Trim();
            string ratingText = RatingTxt.Text.Trim();
            string comment = CommentTxt.Text.Trim();

            // Validate input
            string errorMessage = ValidateInput(customerName, ratingText, comment);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                ErrorLbl.Text = errorMessage;
                return;
            }

            // Search for userId using phoneNumber
            UserRepository userRepo = new UserRepository(); 
          
     

            // Save rating
            int rating = int.Parse(ratingText);
            RatingRepository ratingRepository = new RatingRepository();
            ratingRepository.CreateRating(customerName, rating,comment);

            // Clear form and show success message
            ClearForm();
            ErrorLbl.Text = "Rating submitted successfully!";
            Response.Redirect(Request.Url.AbsoluteUri);

        }

        private string ValidateInput(string fullName, string ratingText, string comment)
        {
            if (string.IsNullOrEmpty(fullName))
            {
                return "Full Name cannot be empty!";
            }
        
            if (string.IsNullOrEmpty(ratingText))
            {
                return "Rating cannot be empty!";
            }
            if (!int.TryParse(ratingText, out int rating) || rating < 1 || rating > 5)
            {
                return "Rating must be a number between 1 and 5!";
            }
            if (string.IsNullOrEmpty(comment))
            {
                return "Comment cannot be empty!";
            }

            return string.Empty;
        }

        private void ClearForm()
        {
            FullNameTxt.Text = string.Empty;
            RatingTxt.Text = string.Empty;
            CommentTxt.Text = string.Empty;
        }
    }
}
    

    
