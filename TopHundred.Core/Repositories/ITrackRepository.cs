using TopHundred.Core.Entities;

namespace TopHundred.Core.Repositories
{
    public interface ITrackRepository : IRepository<Track>
    {
        Track GetByArtistTitle(Artist artist, string title);
    }
}
