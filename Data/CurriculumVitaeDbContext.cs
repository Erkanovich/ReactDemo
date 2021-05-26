using Data.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Data
{
    public class CurriculumVitaeDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public CurriculumVitaeDbContext(DbContextOptions<CurriculumVitaeDbContext> options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
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