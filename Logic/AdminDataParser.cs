﻿using TopHundred.Models;
using System.Linq;

namespace TopHundred.Controllers
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
