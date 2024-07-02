using SEASalon.Factory;
using SEASalon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEASalon.Repository
{
    public class ReservationRepository
    {

        Database1Entities2 db = DatabaseSingleton.getInstance();

        public void CreateReservation(int userId, int serviceId, int branchId, DateTime dateTime)
        {
            Reservation reservation = ReservationFactory.Create(userId, serviceId, branchId, dateTime);
            db.Reservations.Add(reservation);
            db.SaveChanges();
        }

        public List<Reservation> GetAllReservationsbyUserId(int UserId)
        {
            return (from x in db.Reservations where x.UserId == UserId select x).ToList();
        }

        public void CancelReservation(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            db.Reservations.Remove(reservation);
            db.SaveChanges();
        }
    }
}