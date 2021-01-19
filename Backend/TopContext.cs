using Models;
using Microsoft.EntityFrameworkCore;

namespace Backend
{
    public class TopContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<ListEntry> ListEntries { get; set; }
        public DbSet<ReleaseDateInfo> ReleaseDateInfos { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:simonloosveldt.ikdoeict.net\MSSQLSERVER2016,1433;Initial Catalog=simon_loosveldt_TOP100;Persist Security Info=False;User ID=simon_loosveldt_TOP;Password=Azerty123$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");
        }
    }
}
