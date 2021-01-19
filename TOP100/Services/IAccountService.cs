using Models;

namespace TOP100.Services
{
    public interface IAccountService
    {
        User loggedInUser { get; }

        void Login(User user);
        void Logout();
    }
}