using System;
using System.Collections.Generic;
using System.Linq;
using TopHundred.Core.Exceptions;
using TopHundred.Models;

namespace TopHundred.Core
{
    public class ArtistController
    {
        private readonly TopContext db;

        public ArtistController()
        {
            this.db = new TopContext();
        }

        public ArtistController(TopContext topContext)
        {
            this.db = topContext;
            db.SaveChanges();
        }

        public void AddArtist(Artist artist)
        {
            db.Artists.Add(artist);
            db.SaveChanges();
        }

        public Artist AddNewArtist(string name)
        {
            db.Artists.Add(new Artist(name));
            db.SaveChanges();
            return db.Artists.Single(x => x.Name == name);
        }

        public IEnumerable<IArtist> GetAllArtists()
        {
            return db.Artists.AsEnumerable();
        }

        public IArtist GetArtistById(int id)
        {
            return db.Artists.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<ITrack> GetTracksFromArtistById(int id)
        {
            return db.Tracks.AsEnumerable().Where(x => x.Artist.Id == id) ?? throw new ArtistNotFoundException($"Artist with id:{id} has no tracks.");
        }

        public Artist SearchIfExistElseCreateArtist(string artist)
        {
            return db.Artists.Any(x => x.Name == artist) ? db.Artists.Single(x => x.Name == artist) : AddNewArtist(artist);
        }

    }
}
