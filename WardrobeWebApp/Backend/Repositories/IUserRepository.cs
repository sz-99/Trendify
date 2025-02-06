namespace Backend.Repositories
{
    public interface IUserRepository
    {
        bool ValidateUser(string username, string password);
    }
}