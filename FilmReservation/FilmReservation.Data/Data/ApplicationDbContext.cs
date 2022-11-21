using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using FilmReservation.Data.Models;
using FilmReservation.Data.Configuration;

namespace FilmReservation.Data.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        
        public DbSet<Film> Films { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<CinemaHall> CinemaHalls { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Program> Programs { get; set; }
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

            modelBuilder.Entity<Reservation>()
                .HasMany(x => x.Seats)
                .WithMany(x => x.Reservations)
                .UsingEntity<ReservationSeat>(
                    x => x.HasOne(x => x.Seat).WithMany(x => x.ReservationSeats),
                    x => x.HasOne(x => x.Reservation).WithMany(x => x.ReservationSeats));
        }
    }
}
