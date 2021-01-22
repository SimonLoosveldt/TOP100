using TopHundred.Core.Exceptions;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using TopHundred.Core.Entities;

namespace TopHundred.Core
{
    public class UserRepository
    {
        private readonly TopContext db;

        public UserRepository(TopContext topContext)
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
            return db.Users.AsEnumerable() ?? throw new UserNotFoundException($"No users in database.");
        }

        public User GetUserById(int id)
        {
            return db.Users.Where(x => x.Id == id).FirstOrDefault() ?? throw new UserNotFoundException($"No user with id:{id} in database.");
        }

        public IEnumerable<ListEntry> GetListEntriesFromUserById(int id)
        {
            return db.ListEntries.Include(x => x.Track).ThenInclude(x => x.Artist).AsEnumerable().Where(x => x.User.Id == id) ?? throw new ListEntryNotFoundException($"No list entries for user with id:{id} in database.");
        }

        public User GetUserByName(string firstname, string lastname)
        {
            return db.Users.Where(x => x.Firstname == firstname && x.Lastname == lastname).FirstOrDefault() ?? throw new UserNotFoundException($"No user with firstname:{firstname} & lastname:{lastname} in database.");
        }
    }
}
