using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class AdminDataParser
    {

        private readonly TopContext db = new TopContext();

        public AdminDataParser()
        {

        }

        public int GetCountSubmissionEntries()
        {
            return db.Tracks.AsEnumerable().Count();
        }

        public int GetCountCompletedEntries()
        {
            return db.Users.Where(x => x.Completed == true).Count();
        }

        public int GetCountTracks()
        {
            return db.Tracks.Count();
        }

        public int GetCountNonSpotifyTracks()
        {
            return db.Tracks.Where(x => x.ManualEntry == true).Count();
        }
    }
}
