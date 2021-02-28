using Microsoft.EntityFrameworkCore;
using System;

namespace FiledTest.Data
{
    public class FiledTestDataContext : DbContext
    {
        public FiledTestDataContext(DbContextOptions<FiledTestDataContext> dbContextOptions): base(dbContextOptions)
        {
           
        }
        public DbSet<DataModels.Payment> Payments { get; set; }
    }
}
