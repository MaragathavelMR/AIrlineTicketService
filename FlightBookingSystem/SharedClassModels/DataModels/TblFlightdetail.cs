using System;
using System.Collections.Generic;

#nullable disable

namespace SharedClassModels.DataModels
{
    public partial class TblFlightdetail
    {
        public int FlightId { get; set; }
        public int? AirlineId { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime? StrtDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string SchdDays { get; set; }
        public string InstrUsed { get; set; }
        public int? NumBusinessSeats { get; set; }
        public int? NumEconomySeats { get; set; }
        public int? TicketFare { get; set; }
        public int? NoofRows { get; set; }
        public string MealDetails { get; set; }
    }
}
