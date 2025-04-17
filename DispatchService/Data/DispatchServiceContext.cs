using DispatchService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace DispatchService.Data
{
    public class DispatchServiceContext : DbContext
    {
        public DispatchServiceContext(DbContextOptions<DispatchServiceContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DispatchAnnexes>()
                .HasOne(p => p.Dispatch)
                .WithMany(p => p.DispatchAnexes)
                .HasForeignKey(p => p.IdDespacho);
        }

        public DbSet<Dispatch> CMPDispatch { get; set; }
        public DbSet<DispatchAnnexes> CMPDispatchAnnexes { get; set; }
    }
}
