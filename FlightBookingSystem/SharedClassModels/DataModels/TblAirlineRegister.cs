using System;
using System.Collections.Generic;

#nullable disable

namespace SharedClassModels.DataModels
{
    public partial class TblAirlineRegister
    {
        public int AirlineId { get; set; }
        public string AirlineName { get; set; }
        public DateTime? RegOn { get; set; }
        public int? IsActive { get; set; }
    }
}
