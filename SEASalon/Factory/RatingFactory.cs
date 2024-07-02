using SEASalon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEASalon.Factory
{
    public class RatingFactory
    {

        public static Rating Create(String customerName, int rate, String comment)
        {
            Rating rating = new Rating();

            rating.CustomerName = customerName;
            rating.Rate = rate;
            rating.Comment = comment;

            return rating;
        }
    }
}
