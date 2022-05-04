using SharedClassModels.DataModels;

namespace AdminFlightRegisterService.Repository
{
    public interface IAirlineRegRepository
    {
        void InsertAirline(TblAirlineRegister airlineRegister);

        void UpdateAirlineStatus(TblAirlineRegister airlineRegister);

        void SaveChanges();
    }
}
