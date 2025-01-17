using Microsoft.EntityFrameworkCore;
using TipoPagosService.Models;

namespace TipoPagosService.Data
{
    public class PayTypeContext : DbContext
    {
        public PayTypeContext(DbContextOptions<PayTypeContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<PayType> CmpTypePay { get; set; }
    }
}
