namespace Backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        WardrobeDBContext _dbContext;

        public UserRepository(WardrobeDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool ValidateUser(string username, string password)
        {
            var user = _dbContext.UserLogins.FirstOrDefault(u => u.UserName == username);
            if (user != null)
            {
                if(user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
