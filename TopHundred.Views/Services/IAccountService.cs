using TopHundred.Core.Entities;

namespace TopHundred.Views.Services
{
    public interface IAccountService
    {
        User LoggedInUser { get; }

        void Login(User user);
        void Logout();
    }
}