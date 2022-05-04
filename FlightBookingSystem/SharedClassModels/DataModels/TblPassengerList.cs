using System;
using System.Collections.Generic;

#nullable disable

namespace SharedClassModels.DataModels
{
    public partial class TblPassengerList
    {
        public int BookingId { get; set; }
        public int? PnrNo { get; set; }
        public string PassngrName { get; set; }
        public string PassngrGender { get; set; }
        public int? PassngrAge { get; set; }
    }
}
