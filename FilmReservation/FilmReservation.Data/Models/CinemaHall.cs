using System.Collections.Generic;

namespace FilmReservation.Data.Models
{
    public class CinemaHall
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalSeats { get; set; }
        public Cinema Cinema { get; set; }
        public List<Seat> Seats { get; set; }
        public List<Program> Programs { get; set; }
    }
}
