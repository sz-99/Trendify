namespace Backend.Services
{
    public interface ILoginService
    {
        bool ValidateUser(string username, string password);
    }
}