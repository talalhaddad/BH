using BHBackendAPI.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BHBackendAPI.Database
{
    public class BHContext : DbContext
    {
        public BHContext(DbContextOptions<BHContext> options) : base(options)
        {
        }
        public DbSet<TransactionsDBModel> Transactions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionsDBModel>().ToTable("Transactions", "dbo");
        }
    }
}
