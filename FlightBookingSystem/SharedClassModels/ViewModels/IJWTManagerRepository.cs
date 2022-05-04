using SharedClassModels.DataModels;


namespace SharedClassModels.ViewModels
{
    public interface IJWTManagerRepository
    {
        TokenDetails Authenticate(TblUserName users);

        TokenDetails AdminAuthenticate(TblAdminDetail users);
    }
}
