using SharedClassModels.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace UserFlightBookingService.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AirlineDBContext _dbContext;

        public BookingRepository(AirlineDBContext Dbcontext)
        {
                _dbContext= Dbcontext;
        }
        public void CancelBookings(string emailid)
        {
            var bookings = _dbContext.TblBookingdetails.FirstOrDefault(p => p.MailId == emailid);
            _dbContext.TblBookingdetails.Remove(bookings);
            Save();
        }

        public void InsertBookings(TblBookingdetail bookingdetails)
        {
            _dbContext.TblBookingdetails.Add(bookingdetails);
            //if(passengerList!=null)
            //{
            //    foreach(var passenger in passengerList)
            //    {
            //        _dbContext.TblPassengerLists.Add(passenger);
            //    }
            //}           
            Save();
        }

        public void InsertPassengerDetails(TblPassengerList passengerdetails)
        {
            _dbContext.TblPassengerLists.Add(passengerdetails);
            //if(passengerList!=null)
            //{
            //    foreach(var passenger in passengerList)
            //    {
            //        _dbContext.TblPassengerLists.Add(passenger);
            //    }
            //}           
            Save();
        }

        public void InsertUser(TblUserName userName)
        {
            _dbContext.TblUserNames.Add(userName);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public TblBookingdetail ViewBookings(int pnr)
        {
            var bookings= _dbContext.TblBookingdetails.FirstOrDefault(p => p.PnrNo == pnr);
            if(bookings!=null)
            {
                return bookings;    
            }
            else
                return null;
        }

        public TblBookingdetail ViewBookings(string emailid)
        {
            var bookings = _dbContext.TblBookingdetails.FirstOrDefault(p => p.MailId == emailid);
            if (bookings != null)
            {
                return bookings;
            }
            else
                return null;
        }
    }
}
