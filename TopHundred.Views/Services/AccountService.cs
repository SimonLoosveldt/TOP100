using TopHundred.Core.Entities;

namespace TopHundred.Views.Services
{
    public class AccountService : IAccountService
    {
        public User LoggedInUser { get; private set; }

        public AccountService()
        {

        }

        public void Login(User user)
        {
            LoggedInUser = user;
        }

        public void Logout()
        {
            LoggedInUser = null;
        }
    }
}

