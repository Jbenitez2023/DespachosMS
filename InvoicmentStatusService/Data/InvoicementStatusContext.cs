using InvoicmentStatusService.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace InvoicmentStatusService.Data
{
    public class InvoicementStatusContext : DbContext
    {
        public InvoicementStatusContext(DbContextOptions<InvoicementStatusContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<InvoicementStatus> CmpInvoicementStatus { get; set; }
    }
}
