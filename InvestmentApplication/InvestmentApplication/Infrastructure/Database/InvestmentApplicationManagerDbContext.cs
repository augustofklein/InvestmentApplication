using InvestmentApplication.Domain.Investment.Infrastructure.EntityConfiguration;
using InvestmentApplication.Domain.Investment.Model;
using Microsoft.EntityFrameworkCore;

namespace InvestmentApplication.Infrastructure.Database
{
    public class InvestmentApplicationManagerDbContext : DbContext
    {
        public InvestmentApplicationManagerDbContext(DbContextOptions<InvestmentApplicationManagerDbContext> options) : base(options)
        {

        }

        public DbSet<InvestmentEntity> Investment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InvestmentEntityConfiguration());
        }
    }
}
