using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TopHundred.Core.Exceptions;
using TopHundred.Core.Entities;

namespace TopHundred.Core
{
    public class TrackRepository
    {
        private readonly TopContext db;

        public TrackRepository(TopContext topContext)
        {
            this.db = topContext;
            db.SaveChanges();
        }

        public void AddTrack(Track track)
        {
            db.Tracks.Add(track);
        }

        public Track AddNewTrack(string title, Artist artist)
        {
            db.Tracks.Attach(new Track(title, artist));
            db.SaveChanges();
            return db.Tracks.Single(x => x.Artist == artist && x.Title == title);
        }

        public IEnumerable<Track> GetAllTracks()
        {
            return db.Tracks.Include(x => x.Artist).AsEnumerable() ?? throw new TrackNotFoundException("No tracks in database.");
        }

        public Track GetTrackById(int id)
        {
            return db.Tracks.Where(x => x.Id == id).Include(x => x.Artist).FirstOrDefault() ?? throw new TrackNotFoundException($"No track with id:{id} in database.");
        }

        public IEnumerable<ListEntry> GetListEntriesFromTrackById(int id)
        {
            return db.Tracks.Where(x => x.Id == id).Select(x => x.ListEntries).FirstOrDefault() ?? throw new TrackNotFoundException($"No list entries for track with id:{id} in database.");
        }

        public Track GetTrackFromTitleAndArtist(string title, string artist)
        {
            return db.Tracks.Where(x => x.Title == title && x.Artist.Name == artist).FirstOrDefault() ?? throw new TrackNotFoundException($"No track with title:{title} & artist:{artist} in database.");
        }

        public Track SearchIfExistElseCreateTrack(string title, Artist artist)
        {
            return db.Tracks.Any(x => x.Artist == artist && x.Title == title) ? db.Tracks.Single(x => x.Artist == artist && x.Title == title) : AddNewTrack(title, artist);
        }
    }
}
