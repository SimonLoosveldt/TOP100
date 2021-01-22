using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TopHundred.Core.ViewModels;
using TopHundred.Core.Entities;

namespace TopHundred.Core.Controllers
{
    public class InputController
    {
        private readonly TopContext db;
        private readonly TrackRepository trackRepository;
        private readonly ArtistRepository artistRepository;
        private readonly ListEntryRepository listEntryRepository;

        public InputController(TopContext topContext)
        {
            this.db = topContext;
            this.trackRepository = new TrackRepository(db);
            this.artistRepository = new ArtistRepository(db);
            this.listEntryRepository = new ListEntryRepository(db);
            db.SaveChanges();
        }

        public void UpdateDatabase(User user, List<ListEntryViewModel> userListEntries)
        {
            foreach (var listEntry in userListEntries)
            {
                if (string.IsNullOrEmpty(listEntry.Artist) && string.IsNullOrEmpty(listEntry.Title))
                {
                    if (listEntryRepository.SearchIfListEntryExist(user, listEntry.Points))
                    {
                        listEntryRepository.DeleteListEntry(user, listEntry.Points);
                    }
                }
                else
                {
                    var retrievedArtist = artistRepository.SearchIfExistElseCreateArtist(listEntry.Artist);
                    var retrievedTrack = trackRepository.SearchIfExistElseCreateTrack(listEntry.Title, retrievedArtist);

                    if (listEntryRepository.SearchIfListEntryExist(user, listEntry.Points))
                    {
                        listEntryRepository.ChangeListEntryParams(user, retrievedTrack, listEntry.Points);
                    }
                    else
                    {
                        listEntryRepository.AddNewListEntry(user, retrievedTrack, listEntry.Points);
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
