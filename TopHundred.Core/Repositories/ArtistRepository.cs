using TopHundred.Core.Entities;
using System.Linq;
using TopHundred.Core.Exceptions;

namespace TopHundred.Core.Repositories
{
    public class ArtistRepository : BaseRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(TopContext db) : base(db)
        {
        }

        public Artist GetByName(string name)
        {
            return _db.Artists.SingleOrDefault(x => x.Name == name) ?? throw new ArtistNotFoundException($"Artist with name {name} not found in database.");
        }
    }
}
