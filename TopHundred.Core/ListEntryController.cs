using TopHundred.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopHundred.Core
{
    public class ListEntryController
    {
        private readonly TopContext db;

        public ListEntryController()
        {
            this.db = new TopContext();
            db.SaveChanges();
        }

        public ListEntryController(TopContext topContext)
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

        public IEnumerable<IListEntry> GetAllListEntries()
        {
            return db.ListEntries.AsEnumerable();
        }

        public void DeleteListEntry(User user, int points)
        {
            db.ListEntries.Remove(db.ListEntries.Single(x => x.User == user && x.Points == points));
            db.SaveChanges();
        }

        public IListEntry GetListEntryById(int id)
        {
            return db.ListEntries.Where(x => x.Id == id).FirstOrDefault();
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
