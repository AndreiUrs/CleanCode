
using System;
using System.Collections.Generic;

namespace CleanCode.LongParameterList
{
    public class DateRange
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public DateRange(DateTime dateFrom, DateTime dateTo)
        {
            DateFrom = dateFrom;
            DateTo = dateTo;
        }
    }

    public class ReservationQuery
    {
        public LocationType _locationType;
        public int _locationId;
        public User _user;
        public DateRange _dateRange;

        public ReservationQuery(DateRange dateRange, User user, int locationId, LocationType locationType)
        {
            _dateRange = dateRange;
            _user = user;
            _locationId = locationId;
            _locationType = locationType;
        }
    }


    public class LongParameterList
    {
        public IEnumerable<Reservation> GetReservations(ReservationQuery reservationQuery, int? customerId = null)
        {
            if (reservationQuery._dateRange.DateFrom >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (reservationQuery._dateRange.DateTo <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }

        public IEnumerable<Reservation> GetUpcomingReservations(ReservationQuery query)
        {
            if (query._dateRange.DateFrom >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (query._dateRange.DateTo <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }

        private static Tuple<DateTime, DateTime> GetReservationDateRange(DateRange dateRange, ReservationDefinition sd)
        {
            if (dateRange.DateFrom >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (dateRange.DateTo <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }

        public void CreateReservation(DateRange dateRange, int locationId)
        {
            if (dateRange.DateFrom >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (dateRange.DateTo <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }
    }

    internal class ReservationDefinition
    {
    }

    public class LocationType
    {
    }

    public class User
    {
        public object Id { get; set; }
    }

    public class Reservation
    {
    }
}
