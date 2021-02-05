using Microsoft.EntityFrameworkCore;

namespace TopHundred.Core.Entities
{
    public class TopContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<ListEntry> ListEntries { get; set; }
        public DbSet<ReleaseDateInfo> ReleaseDateInfos { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<User> Users { get; set; }

        //public TopContext()
        //{

        //}
        //public TopContext(DbContextOptions options) : base(options)
        //{

        //}
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TOP100;Integrated Security=True");
        }
    }
}
