using TopHundred.Core.Entities;

namespace TopHundred.Core.Services
{
    public interface IUserService
    {
        User GetCurrentUser();
        bool IsLoggedIn();
        void Login(User user);
        void Logout();
    }
}
