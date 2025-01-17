using AccountingconceptService.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountingconceptService.Data
{
    public class AccountingConceptContext : DbContext
    {
        public AccountingConceptContext(DbContextOptions<AccountingConceptContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<AccountingConcept> CMPAccountingConcept { get; set; }
    }
}
