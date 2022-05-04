using SharedClassModels.DataModels;


namespace AdminFlightRegisterService
{
    public interface IFlightRegRepository
    {
        void InsertFlightDetails(TblFlightdetail flDetails);

        void DeleteFlightDetails(TblFlightdetail flDetails);

        void SaveFlightDetails();
    }
}
