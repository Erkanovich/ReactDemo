using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CurriculumVitaeDbContext : DbContext
    {
        public CurriculumVitaeDbContext(DbContextOptions<CurriculumVitaeDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ContactMe>()
                .HasKey(x => x.Id);

            modelBuilder
                .Entity<ContactMe>()
                .Property(x => x.Id)
                .UseIdentityColumn(1, 1);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ContactMe> ContactMes { get; set; }
    }
}