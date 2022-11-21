using System;

namespace FilmReservation.Data.Models
{
    public class Program
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public Film Film { get; set; }
        public CinemaHall CinemaHall { get; set; }
    }
}
