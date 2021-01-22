using TopHundred.Core.Entities;

namespace TopHundred.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByName(string firstName, string lastName);
    }
}
