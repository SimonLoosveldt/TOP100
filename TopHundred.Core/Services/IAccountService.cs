using TopHundred.Core.Entities;

namespace TopHundred.Core.Services
{
    public interface IAccountService
    {
        User LoggedInUser { get; }

        void Login(User user);
        void Logout();
    }
}