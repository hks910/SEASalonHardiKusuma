using SEASalon.Factory;
using SEASalon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEASalon.Repository
{
    public class RatingRepository
    {
        Database1Entities2 db = DatabaseSingleton.getInstance();

        public void CreateRating(String customerName, int rate, String comment)
        {
            Rating rating = RatingFactory.Create(customerName, rate, comment);
            db.Ratings.Add(rating);
            db.SaveChanges();
        }

        public List<Rating> GetRatings()
        {
            return (from x in db.Ratings select x).ToList();
        }
    }
}