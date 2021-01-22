using System;
using TopHundred.Core.Entities;

namespace TopHundred.Core.Services
{
    public class UserService : IUserService
    {
        private User currentUser;

        public User GetCurrentUser() => currentUser;       
        public bool IsLoggedIn() => currentUser != null;
        public void Login(User user)
        {
            currentUser = user ?? throw new ArgumentException("Argument 'user' can't be null");
        }
        public void Logout()
        {
            currentUser = null;
        }
    }
}
