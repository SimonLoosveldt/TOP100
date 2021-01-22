using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TopHundred.Core.ViewModels;
using TopHundred.Core.Entities;

namespace TopHundred.Core
{
    public class InputController
    {
        private readonly TopContext db;
        private readonly TrackRepository trackController;
        private readonly ArtistRepository artistController;
        private readonly ListEntryRepository listEntryController;

        public InputController()
        {
            this.db = new TopContext();
            this.trackController = new TrackRepository();
            this.artistController = new ArtistRepository();
            this.listEntryController = new ListEntryRepository();
            db.SaveChanges();
        }

        public void UpdateDatabase(User user, List<ListEntryViewModel> userListEntries)
        {
            foreach (var listEntry in userListEntries)
            {
                if (string.IsNullOrEmpty(listEntry.Artist) && string.IsNullOrEmpty(listEntry.Title))
                {
                    if (listEntryController.SearchIfListEntryExist(user, listEntry.Points))
                    {
                        listEntryController.DeleteListEntry(user, listEntry.Points);
                    }
                }
                else
                {
                    var retrievedArtist = artistController.SearchIfExistElseCreateArtist(listEntry.Artist);
                    var retrievedTrack = trackController.SearchIfExistElseCreateTrack(listEntry.Title, retrievedArtist);

                    if (listEntryController.SearchIfListEntryExist(user, listEntry.Points))
                    {
                        listEntryController.ChangeListEntryParams(user, retrievedTrack, listEntry.Points);
                    }
                    else
                    {
                        listEntryController.AddNewListEntry(user, retrievedTrack, listEntry.Points);
                    }
                }
            }
        }

        public List<ListEntryViewModel> GetPreviousData(User user, int upperLimit, int lowerLimit)
        {
            var previousDataSample = new List<ListEntryViewModel>();
            var allListEntries = GetAllListEntriesFromUser(user);

            for (int i = lowerLimit; i <= upperLimit; i++)
            {
                try
                {
                    var track = allListEntries.Single(x => x.Points == i).Track;
                    previousDataSample.Add(new ListEntryViewModel(i, track.Artist.Name, track.Title));
                }
                catch (InvalidOperationException)
                {
                    previousDataSample.Add(new ListEntryViewModel(i, string.Empty, string.Empty));
                }

            }
            return previousDataSample;
        }

        public IEnumerable<ListEntry> GetAllListEntriesFromUser(User user)
        {
            return db.ListEntries.Include(x => x.User).Include(x => x.Track).ThenInclude(x => x.Artist).Where(x => x.User.Id == user.Id).AsEnumerable();
        }
    }
}
