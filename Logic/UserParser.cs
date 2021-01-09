﻿using Backend;
using Globals;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Logic
{
    public class UserParser
    {
        private readonly TopContext db;

        public UserParser()
        {
            this.db = new TopContext();
        }

        public UserParser(TopContext topContext)
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
            catch (Exception e)
            {
                return null;
            }            
        }

    }
}
