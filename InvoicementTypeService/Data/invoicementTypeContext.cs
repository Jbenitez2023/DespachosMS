using InvoicementTypeService.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoicementTypeService.Data
{
    public class invoicementTypeContext : DbContext
    {
        public invoicementTypeContext(DbContextOptions<invoicementTypeContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public  DbSet<invoicementType> CmpInvoicementTypes { get; set; }
    }
}
