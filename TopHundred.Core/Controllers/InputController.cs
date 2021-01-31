using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TopHundred.Core.ViewModels;
using TopHundred.Core.Entities;
using TopHundred.Core.Repositories;
using TopHundred.Core.Exceptions;

namespace TopHundred.Core.Controllers
{
    public class InputController
    {
        private readonly ITrackRepository _trackRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly IListEntryRepository _listEntryRepository;

        public InputController(IArtistRepository artistRepository, ITrackRepository trackRepository, IListEntryRepository listEntryRepository)
        {
            _artistRepository = artistRepository;
            _trackRepository = trackRepository;
            _listEntryRepository = listEntryRepository;
        }

        public void Sync(User user, List<ListEntryViewModel> userListEntries)
        {
            foreach (var listEntry in userListEntries)
            {
                if (listEntry.IsEmpty())
                {
                    var entries = _listEntryRepository.Search(x => x.User == user && x.Points == listEntry.Points);
                    if (entries.Any())
                    {
                        _listEntryRepository.Remove(entries);
                    }                  
                }
                else
                {
                    var artist = TryFindArtist(listEntry.Artist);
                    var track = TryFindTrack(artist, listEntry.Title);
                    CreateListEntry(user, track, listEntry.Points);                    
                }
            }
        }     
        public List<ListEntryViewModel> GetPreviousData(User user, int upperLimit, int lowerLimit)
        {
            var previousDataSample = new List<ListEntryViewModel>();
            var entries = _listEntryRepository.GetAll().ToList();

            for (int points = lowerLimit; points <= upperLimit; points++)
            {
                try
                {
                    var track = entries.Single(x => x.Points == points).Track;
                    previousDataSample.Add(new ListEntryViewModel(points, track.Artist.Name, track.Title));
                }
                catch (InvalidOperationException)
                {
                    previousDataSample.Add(new ListEntryViewModel(points));
                }

            }
            return previousDataSample;
        }

        private Track TryFindTrack(Artist artist, string title)
        {
            Track track;
            try
            {
                track = _trackRepository.GetByArtistTitle(artist, title);
            }
            catch (TrackNotFoundException)
            {
                track = new Track
                {
                    Artist = artist,
                    Title = title,                    
                };
                _trackRepository.Add(track);
            }
            return track;
        }
        private Artist TryFindArtist(string name)
        {
            Artist artist;
            try
            {
                artist = _artistRepository.GetByName(name);

            }
            catch (ArtistNotFoundException)
            {
                artist = new Artist()
                {
                    Name = name,
                };
                _artistRepository.Add(artist);
            }

            return artist;
        }
        private ListEntry CreateListEntry(User user, Track track, int points)
        {
            ListEntry listEntry;
            try
            {
                listEntry = _listEntryRepository.GetByUserPoints(user, points);

            }
            catch (ListEntryNotFoundException)
            {
                listEntry = new ListEntry
                {
                    Points = points,
                    Track = track,
                    User = user,
                    Year = 0,
                };
                _listEntryRepository.Add(listEntry);
            }

            return listEntry;
        }
    }
}
