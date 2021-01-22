using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopHundred.Models;

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
