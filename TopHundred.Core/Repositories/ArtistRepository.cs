using System.Collections.Generic;
using System.Linq;
using TopHundred.Core.Entities;
using TopHundred.Core.Exceptions;

namespace TopHundred.Core
{
    public class ArtistRepository
    {
        private readonly TopContext db;

        public ArtistRepository(TopContext db)
        {
            this.db = db;
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

        public IEnumerable<Artist> GetAllArtists()
        {
            return db.Artists.AsEnumerable() ?? throw new ArtistNotFoundException("No artists in database.");
        }

        public Artist GetArtistById(int id)
        {
            return db.Artists.Where(x => x.Id == id).FirstOrDefault() ?? throw new ArtistNotFoundException($"No artist with id:{id} in database.");
        }

        public IEnumerable<Track> GetTracksFromArtistById(int id)
        {
            return db.Tracks.AsEnumerable().Where(x => x.Artist.Id == id) ?? throw new ArtistNotFoundException($"Artist with id:{id} has no tracks.");
        }

        public Artist SearchIfExistElseCreateArtist(string artist)
        {
            return db.Artists.Any(x => x.Name == artist) ? db.Artists.Single(x => x.Name == artist) : AddNewArtist(artist);
        }
    }
}
