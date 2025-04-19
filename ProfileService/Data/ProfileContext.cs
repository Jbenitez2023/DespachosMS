using Microsoft.EntityFrameworkCore;
using ProfileService.Models;

namespace ProfileService.Data
{
    public class ProfileContext : DbContext
    {
        public ProfileContext(DbContextOptions<ProfileContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Profile> CmpProfiles { get; set; }
    }
}
