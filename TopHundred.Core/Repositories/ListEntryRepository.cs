using System;
using System.Collections.Generic;
using System.Linq;
using TopHundred.Core.Entities;
using TopHundred.Core.Exceptions;

namespace TopHundred.Core
{
    public class ListEntryRepository
    {
        private readonly TopContext db;

        public ListEntryRepository(TopContext topContext)
        {
            this.db = topContext;
            db.SaveChanges();
        }

        public void AddListEntry(ListEntry listEntry)
        {
            db.ListEntries.Add(listEntry);
            db.SaveChanges();
        }

        public void AddNewListEntry(User loggedInUser, Track track, int points)
        {
            db.ListEntries.Attach(new ListEntry(loggedInUser, track, points, DateTime.Now.Year));
            db.SaveChanges();
        }

        public IEnumerable<ListEntry> GetAllListEntries()
        {
            return db.ListEntries.AsEnumerable() ?? throw new ListEntryNotFoundException("No listentries in database.");
        }

        public void DeleteListEntry(User user, int points)
        {
            db.ListEntries.Remove(db.ListEntries.Single(x => x.User == user && x.Points == points));
            db.SaveChanges();
        }

        public ListEntry GetListEntryById(int id)
        {
            return db.ListEntries.Where(x => x.Id == id).FirstOrDefault() ?? throw new ListEntryNotFoundException($"No listentry with id:{id} in database.");
        }

        public bool SearchIfListEntryExist(User loggedInUser, int points)
        {
            return db.ListEntries.Any(x => x.User == loggedInUser && x.Points == points);
        }

        public void ChangeListEntryParams(User user, Track retrievedTrack, int points)
        {
            var listEntryToBeChanged = db.ListEntries.Single(x => x.User == user && x.Points == points);
            listEntryToBeChanged.Track = retrievedTrack;            
            db.ListEntries.Update(listEntryToBeChanged);
            db.SaveChanges();
        }
    }
}
