using TopHundred.Models;
using TopHundred.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopHundred.Views.FrontendLogic
{
    public class LoginHandler
    {
        public UserParser userParser;

        public LoginHandler()
        {
            userParser = new UserParser();
        }

        public User GetFirstUserFromDb()
        {
            return userParser.GetAllUsers().First();
        }

        public Tuple<bool, User> Validate(string firstname, string lastname)
        {
            var userDb = userParser.GetUserByName(firstname.ToLower(), lastname.ToLower());

            if(userDb is null)
            {
                return Tuple.Create(false, userDb);
            }
            else
            {
                return Tuple.Create(true, userDb);
            }
            
        }
    }
}
