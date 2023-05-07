using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmReservation.Data.Data
{
    internal class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "1b18956a-e040-4fd0-8a9e-5e6f0946a4fe",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "7551a98b-46f3-48d7-b9a3-4d27603f313b"
                },
                new IdentityRole
                {
                    Id = "ee2a151e-99b3-4305-a4ef-d25a9320908b",
                    Name = "Client",
                    NormalizedName = "CLIENT",
                    ConcurrencyStamp = "fa893815-597a-4347-b5e8-b91a4ff91988"
                }
            );
        }
    }
}
