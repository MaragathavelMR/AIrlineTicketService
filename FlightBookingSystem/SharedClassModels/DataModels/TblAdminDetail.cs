using System;
using System.Collections.Generic;

#nullable disable

namespace SharedClassModels.DataModels
{
    public partial class TblAdminDetail
    {
        public int UserId { get; set; }
        public string AdminName { get; set; }
        public string AdminPwd { get; set; }
    }
}
