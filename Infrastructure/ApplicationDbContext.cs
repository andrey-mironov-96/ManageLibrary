using Domain.Abstractions;
using Domain.Entities;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public sealed class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        public DbSet<Bookcase> Bookcases { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfigurations());
            modelBuilder.ApplyConfiguration(new BookcaseConfiguration());
            // modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
