using System;
using System.Collections.Generic;

#nullable disable

namespace SharedClassModels.DataModels
{
    public partial class TblBookingdetail
    {
        public int BookingId { get; set; }
        public int? FlightId { get; set; }
        public string UserName { get; set; }
        public string MailId { get; set; }
        public int? NumOfSeats { get; set; }
        public int? PnrNo { get; set; }
        public string MealsAvailed { get; set; }
    }
}
