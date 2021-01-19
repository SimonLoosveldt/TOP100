using Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;

namespace TOP100.Services
{
    public class AccountService : IAccountService
    {
        public User loggedInUser { get; private set; }

        public AccountService()
        {

        }

        public void Login(User user)
        {
            loggedInUser = user;
        }

        public void Logout()
        {
            loggedInUser = null;
        }
    }
}

