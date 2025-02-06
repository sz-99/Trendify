using Backend.Repositories;
namespace Backend.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository _userRepository;

        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool ValidateUser(string username, string password)
        {
            return _userRepository.ValidateUser(username, password);
        }
    }
}