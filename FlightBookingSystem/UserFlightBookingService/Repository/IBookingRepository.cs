using SharedClassModels.DataModels;
using System.Collections.Generic;

namespace UserFlightBookingService
{
    public interface IBookingRepository
    {
        void InsertUser(TblUserName userName);
        void InsertBookings(TblBookingdetail bookingdetails);

        void InsertPassengerDetails(TblPassengerList passengerdetails);

        void CancelBookings(string emailid);

        TblBookingdetail ViewBookings(int pnr);

        TblBookingdetail ViewBookings(string emailid);

        void Save();
    }
}
