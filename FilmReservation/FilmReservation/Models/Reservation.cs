using System;
using System.Collections.Generic;

namespace FilmReservation.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public IEnumerable<Film> Films { get; set; }
        public DateTime ReservationDateTime { get; set; }
    }
}
