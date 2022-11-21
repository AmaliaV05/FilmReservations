using System.Collections.Generic;

namespace FilmReservation.Data.Models
{
    public class Seat
    {
        public int Id { get; set; }
        public int SeatNumber { get; set; }
        public bool Occupied { get; set; }
        public CinemaHall CinemaHall { get; set; }
        public List<Reservation> Reservations { get; set; }
        public List<ReservationSeat> ReservationSeats { get; set; }
    }
}
