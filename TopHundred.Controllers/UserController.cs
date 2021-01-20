using TopHundred.Models;
using TopHundred.Controllers.Exceptions;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace TopHundred.Controllers
{
    public class UserController
    {
        private readonly TopContext db;

        public UserController()
        {
            this.db = new TopContext();
        }

        public UserController(TopContext topContext)
        {
            this.db = topContext;
        }

        public void AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            //return db.Users.AsQueryable().ToList();
            return db.Users.AsEnumerable();
        }

        public User GetUserById(int id)
        {
            return db.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<IListEntry> GetListEntriesFromUserById(int id)
        {
            return db.ListEntries.Include(x => x.Track).ThenInclude(x => x.Artist).AsEnumerable().Where(x => x.User.Id == id);
        }

        public User GetUserByName(string firstname, string lastname)
        {        
            try
            {
                return db.Users.Single(x => x.Firstname == firstname && x.Lastname == lastname);
            }
            catch (InvalidOperationException e)
            {
                throw new UserNotFoundException($"user not found with firstname:{firstname} and lastname:{lastname}", e);
            }         
        }
    }
}
