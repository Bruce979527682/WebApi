using Entity.Api;
using Microsoft.EntityFrameworkCore;

namespace Data.Api
{
    public class ApiContext: DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable("Account");            
        }

    }
}
