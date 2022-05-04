using SharedClassModels.DataModels;


namespace AdminFlightRegisterService.Repository
{
    public class FlightRegRepository : IFlightRegRepository
    {

        private readonly AirlineDBContext _dbContext;
        public FlightRegRepository(AirlineDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteFlightDetails(TblFlightdetail flDetails)
        {
            var flightDet = _dbContext.TblFlightdetails.Find(flDetails);
            _dbContext.TblFlightdetails.Remove(flightDet);
            SaveFlightDetails();
        }

        public void InsertFlightDetails(TblFlightdetail flDetails)
        {
            _dbContext.TblFlightdetails.Add(flDetails);
            SaveFlightDetails();
        }

        public void SaveFlightDetails()
        {
            _dbContext.SaveChanges();
        }
    }
}
