using System.Linq;
using TopHundred.Core.Entities;

namespace TopHundred.Core.Controllers
{
    public class AdminController
    {

        private readonly TopContext db;

        public AdminController(TopContext topContext)
        {
            this.db = topContext;
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
