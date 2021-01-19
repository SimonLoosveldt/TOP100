using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Controllers;

namespace TOP100.FrontendLogic
{
    public class AdminDataHandler
    {
        private AdminDataParser AdminDataParser { get; set; }

        public AdminDataHandler()
        {
            AdminDataParser = new AdminDataParser();
        }

        public int GetSubmissionEntries()
        {
            return AdminDataParser.GetCountSubmissionEntries();
        }

        public int GetCompletedEntries()
        {
            return AdminDataParser.GetCountCompletedEntries();
        }

        public int GetCountTracks()
        {
            return AdminDataParser.GetCountTracks();
        }

        public int GetNonSpotifyTracks()
        {
            return AdminDataParser.GetCountNonSpotifyTracks();
        }
    }
}
