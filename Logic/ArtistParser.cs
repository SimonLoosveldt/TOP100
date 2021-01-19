using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class ArtistParser
    {
        private readonly TopContext db;

        public ArtistParser()
        {
            this.db = new TopContext();
        }

        public ArtistParser(TopContext topContext)
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
            //return db.ListEntries.Include(x => x.Track).ThenInclude(x => x.Artist).AsEnumerable().Where(x => x.User.Id == id);
            return db.Tracks.AsEnumerable().Where(x => x.Artist.Id == id);
        }

        public Artist SearchIfExistElseCreateArtist(string artist)
        {
            return db.Artists.Any(x => x.Name == artist) ? db.Artists.Single(x => x.Name == artist) : AddNewArtist(artist);
        }

    }
}
