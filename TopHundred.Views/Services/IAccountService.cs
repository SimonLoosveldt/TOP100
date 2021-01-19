using TopHundred.Models;

namespace TopHundred.Views.Services
{
    public interface IAccountService
    {
        User loggedInUser { get; }

        void Login(User user);
        void Logout();
    }
}