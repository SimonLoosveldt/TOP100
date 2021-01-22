using System.Linq;
using TopHundred.Core.Entities;
using TopHundred.Core.Exceptions;

namespace TopHundred.Core.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(TopContext db) : base(db)
        {
        }

        public User GetByName(string firstName, string lastName)
        {
            return _db.Users.SingleOrDefault(x => x.Firstname == firstName && x.Lastname == lastName) ?? throw new UserNotFoundException($"User with name {firstName} {lastName} not found in database.");
        }
    }
}
