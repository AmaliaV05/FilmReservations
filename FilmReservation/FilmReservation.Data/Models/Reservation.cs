using System;
using System.Collections.Generic;

namespace FilmReservation.Data.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Program Program { get; set; }
        public List<Seat> Seats { get; set; }
        public List<ReservationSeat> ReservationSeats { get; set; }
    }
}
