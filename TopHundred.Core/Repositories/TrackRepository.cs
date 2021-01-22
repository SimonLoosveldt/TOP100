using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TopHundred.Core.Exceptions;
using TopHundred.Core.Entities;

namespace TopHundred.Core.Repositories
{
    public class TrackRepository : BaseRepository<Track>, ITrackRepository
    {
        public TrackRepository(TopContext db) : base(db)
        {
        }

        public Track GetByArtistTitle(Artist artist, string title)
        {
            return _db.Tracks.SingleOrDefault(x => x.Artist == artist && x.Title == title) ?? throw new TrackNotFoundException($"Track {title} from artist {artist} not found");
        }
    }
}
