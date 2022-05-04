using SharedClassModels.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedClassModels.ViewModels
{
    public interface IAdminNUserRegister
    {
        void InsertUser(TblUserName userDet);

        void InsertAdmin(TblAdminDetail AdminDet);

        void save();
    }
}
