using System;
using System.Collections.Generic;

#nullable disable

namespace SharedClassModels.DataModels
{
    public partial class TblUserName
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string MailId { get; set; }
        public string PassWord { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastPwdChanged { get; set; }
    }
}
