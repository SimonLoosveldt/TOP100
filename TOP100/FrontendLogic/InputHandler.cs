using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Controllers;
using TOP100.ViewModels;

namespace TOP100.FrontendLogic
{
    public class InputHandler
    {
        private InputParser InputParser { get; set; }
        private ArtistParser ArtistParser { get; set; }
        private TrackParser TrackParser { get; set; }
        private ListEntryParser ListEntryParser { get; set; }


        public InputHandler()
        {
            InputParser = new InputParser();
            ArtistParser = new ArtistParser();
            TrackParser = new TrackParser();
            ListEntryParser = new ListEntryParser();
        }

        public void UpdateDatabase(User user, List<ListEntryViewModel> userListEntries)
        {
            foreach(var listEntry in userListEntries)
            {
                if (String.IsNullOrEmpty(listEntry.Artist) && String.IsNullOrEmpty(listEntry.Title))
                {
                    if (ListEntryParser.SearchIfListEntryExist(user, listEntry.Points))
                    {
                        ListEntryParser.DeleteListEntry(user, listEntry.Points);
                    }
                }
                else
                {
                    var retrievedArtist = ArtistParser.SearchIfExistElseCreateArtist(listEntry.Artist);
                    var retrievedTrack = TrackParser.SearchIfExistElseCreateTrack(listEntry.Title, retrievedArtist);

                    if (ListEntryParser.SearchIfListEntryExist(user, listEntry.Points))
                    {
                        ListEntryParser.ChangeListEntryParams(user, retrievedTrack, listEntry.Points);
                    }
                    else
                    {
                        ListEntryParser.AddNewListEntry(user, retrievedTrack, listEntry.Points);
                    }
                }
            }
        }

        public List<ListEntryViewModel> GetPreviousData(User user, int upperlimit, int lowerlimit)
        {
            var previousDataSample = new List<ListEntryViewModel>();
            var allListEntries = InputParser.GetAllListEntriesFromUser(user);

            for(int i = lowerlimit; i <= upperlimit; i++)
            {
                try
                {
                    var track = allListEntries.Single(x => x.Points == i).Track;
                    previousDataSample.Add(new ListEntryViewModel(i, track.Artist.Name, track.Title));
                }
                catch (Exception e)
                {
                    previousDataSample.Add(new ListEntryViewModel(i, string.Empty, string.Empty));
                }
                
            }
            return previousDataSample;
        }
    }
}
