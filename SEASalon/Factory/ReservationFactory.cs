using SEASalon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEASalon.Factory
{
    public class ReservationFactory
    {
        public static Reservation Create(int userId, int serviceId, int branchId, DateTime dateTime)
        {
            Reservation reservation = new Reservation();

            reservation.UserId = userId;
            reservation.ServiceId = serviceId;
            reservation.BranchId = branchId;
            reservation.ReservationTime = dateTime;

            return reservation;
        }

    }
}
