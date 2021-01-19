using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Controllers
{
    public class TrackParser
    {
        private readonly TopContext db;


        public TrackParser()
        {
            this.db = new TopContext();
            db.SaveChanges();
        }

        public TrackParser(TopContext topContext)
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
            return db.Tracks.Include(x => x.Artist).AsEnumerable();
        }

        public ITrack GetTrackById(int id)
        {
            return db.Tracks.Where(x => x.Id == id).Include(x => x.Artist).FirstOrDefault();
        }

        public IEnumerable<IListEntry> GetListEntriesFromTrackById(int id)
        {
            return db.Tracks.Where(x => x.Id == id).Select(x => x.ListEntries).FirstOrDefault();
        }

        public Track GetTrackFromTitleAndArtist(string title, string artist)
        {
            try
            { 
                return db.Tracks.Single(x => x.Title == title && x.Artist.Name == artist);
            } 
            catch (ArgumentNullException e)
            {
                return null;
            }
            
        }

        public Track SearchIfExistElseCreateTrack(string title, Artist artist)
        {
            return db.Tracks.Any(x => x.Artist == artist && x.Title == title) ? db.Tracks.Single(x => x.Artist == artist && x.Title == title) : AddNewTrack(title, artist);
        }

    }
}
