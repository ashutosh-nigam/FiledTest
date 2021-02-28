using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace FiledTest.Data
{
    public class FiledTestDataContext : DbContext
    {
        public FiledTestDataContext(DbContextOptions<FiledTestDataContext> dbContextOptions, ILogger<FiledTestDataContext> logger) : base(dbContextOptions)
        {
            this.ChangeTracker.LazyLoadingEnabled = true;           
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.LogTo(Console.WriteLine);
        public DbSet<DataModels.PaymentInfo> PaymentsInfo { get; set; }
        public DbSet<DataModels.PaymentStatus> PaymentsStatuses { get; set; }
    }
}
