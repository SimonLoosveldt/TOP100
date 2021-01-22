using TopHundred.Core.Entities;

namespace TopHundred.Core.Repositories
{
    public interface IArtistRepository : IRepository<Artist>
    {
        Artist GetByName(string name);
    }
}
