﻿using TopHundred.Core.Entities;

namespace TopHundred.Core.Services
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

