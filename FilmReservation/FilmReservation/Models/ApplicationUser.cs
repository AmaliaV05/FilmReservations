using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FilmReservation.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Reservation> Reservations { get; set; }
    }
}
