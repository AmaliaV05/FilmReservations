using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using FilmReservation.Data.Models;

namespace FilmReservation.Data.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        
        public DbSet<Film> Films { get; set; }        
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Film>()
                .HasIndex(p => p.Title)
                .IsUnique()
                .HasFilter(null);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
