using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TopHundred.Core.Entities;
using TopHundred.Core.Exceptions;

namespace TopHundred.Core.Repositories
{
    public class ListEntryRepository : BaseRepository<ListEntry>, IListEntryRepository
    {
        public ListEntryRepository(TopContext topContext) : base(topContext)
        {            
        }

        public ListEntry GetByUserPoints(User user, int points)
        {
            return _db.ListEntries.SingleOrDefault(x => x.User == user && x.Points == points) ?? throw new ListEntryNotFoundException($"ListEntry for user {user} with {points} points not found.");
        }
        public IEnumerable<ListEntry> GetByUser(User user) => Search(x => x.User.Id == user.Id);

        public override IQueryable<ListEntry> GetAll()
        {
            return base.GetAll().Include(x => x.User).Include(x => x.Track);
        }
    }
}
