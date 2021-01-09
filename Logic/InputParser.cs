using Backend;
using Globals;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class InputParser
    {
        private readonly TopContext db;
        private readonly TrackParser trackParser;

        public InputParser()
        {
            this.db = new TopContext();
            this.trackParser = new TrackParser();
        }

        public InputParser(TopContext topContext)
        {
            this.db = topContext;
            this.trackParser = new TrackParser();
            db.SaveChanges();
        }

        public void UpdateDb(User user, Dictionary<int, List<string>> inputValues)
        {
            foreach(var listEntry in inputValues)
            {
                if(TrackAlreadyInDb(listEntry.Value))
                {
                    if(db.ListEntries.Any(x => x.User == user && x.Points == listEntry.Key))
                    {

                    }

                }
                else
                {
                    
                }
            }             
        }

        public bool NullCheckInputList(List<string> inputValues)
        {
            var isOk = true;

            foreach(var artistOrTitle in inputValues)
            {
                if(String.IsNullOrEmpty(artistOrTitle))
                {
                    isOk = false;
                }
                else
                {
                    isOk = true;
                }
            }

            return isOk;
        }

        public bool TrackAlreadyInDb(List<string> inputValues)
        {
            return db.Tracks.Any(x => x.Title == inputValues[1] && x.Artist.Name == inputValues[1]);          
        }

        public IEnumerable<ListEntry> GetAllListEntriesFromUser(User user)
        {
            return db.ListEntries.Include(x => x.User).Include(x => x.Track).ThenInclude(x => x.Artist).Where(x => x.User.Id == user.Id).AsEnumerable();
        }
    }
}
