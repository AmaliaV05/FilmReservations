using System.Collections.Generic;

namespace FilmReservation.Data.Models
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalHalls { get; set; }
        public List<CinemaHall> CinemaHalls { get; set; }
    }
}
