using TopHundred.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;

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

