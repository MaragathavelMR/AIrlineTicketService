using SharedClassModels.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedClassModels.ViewModels
{

    public class AdminNUserRegister : IAdminNUserRegister
    {
        private readonly AirlineDBContext _dbContext;
        public AdminNUserRegister(AirlineDBContext dbContext)
        {
            _dbContext=dbContext;
        }
        public void InsertAdmin(TblAdminDetail AdminDet)
        {
            _dbContext.TblAdminDetails.Add(AdminDet);
            save();
        }

        public void InsertUser(TblUserName userDet)
        {
            _dbContext.TblUserNames.Add(userDet);
            save();
        }

        public void save()
        {
            _dbContext.SaveChanges();
        }
    }
}
