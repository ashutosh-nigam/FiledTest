using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace FiledTest.Data
{
    public class FiledTestDataContext : DbContext
    {
        public FiledTestDataContext()
        {

        }
        public FiledTestDataContext(DbContextOptions dbContextOptions, ILogger<FiledTestDataContext> logger) : base(dbContextOptions)
        {
            this.ChangeTracker.LazyLoadingEnabled = true;           
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-KUQSHPG;Integrated Security=True;Initial Catalog=FiledTestDb");
            }
        }
        public DbSet<DataModels.PaymentInfo> PaymentsInfo { get; set; }
        public DbSet<DataModels.PaymentStatus> PaymentsStatuses { get; set; }
    }
}
