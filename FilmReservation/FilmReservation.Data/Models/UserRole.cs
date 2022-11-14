using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmReservation.Data.Models
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
                    Id = "6facc23c-e274-41b1-9ac1-8efb7b71689d",
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE",
                    ConcurrencyStamp = "c4b1fccd-35d0-455a-b28e-3f66293c68e6"
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
