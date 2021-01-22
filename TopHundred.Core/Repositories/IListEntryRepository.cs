using System.Collections.Generic;
using TopHundred.Core.Entities;

namespace TopHundred.Core.Repositories
{
    public interface IListEntryRepository : IRepository<ListEntry>
    {
        ListEntry GetByUserPoints(User user, int points);
        IEnumerable<ListEntry> GetByUser(User user);        
    }
}
