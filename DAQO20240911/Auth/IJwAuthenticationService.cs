namespace DAQO20240911.Auth
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(string userName);
    }
}
