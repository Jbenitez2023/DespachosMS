using Microsoft.EntityFrameworkCore;
using OperationTypeService.Models;

namespace OperationTypeService.Data
{
    public class OperationTypeContext :DbContext
    {
        public OperationTypeContext(DbContextOptions<OperationTypeContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<OperationType> CmpOperationTypes { get; set; }
    }
}
