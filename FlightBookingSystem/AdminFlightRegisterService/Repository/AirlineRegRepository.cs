using Microsoft.EntityFrameworkCore;
using SharedClassModels.DataModels;

namespace AdminFlightRegisterService.Repository
{
    public class AirlineRegRepository : IAirlineRegRepository
    {
        private readonly AirlineDBContext _dbContext;

        public AirlineRegRepository(AirlineDBContext dbContext)
        {
            _dbContext=dbContext; 
        }
        public void InsertAirline(TblAirlineRegister airlineRegister)
        {
           _dbContext.TblAirlineRegisters.Add(airlineRegister);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges(); 
        }

        public void UpdateAirlineStatus(TblAirlineRegister airlineRegister)
        {
            _dbContext.Entry(airlineRegister).State = EntityState.Modified;
            SaveChanges();
        }

    }
}
