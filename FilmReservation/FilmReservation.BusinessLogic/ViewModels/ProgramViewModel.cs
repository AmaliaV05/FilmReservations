using System;

namespace FilmReservation.BusinessLogic.ViewModels
{
    public class ProgramViewModel
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public FilmViewModel Film { get; set; }
        public CinemaHallViewModel CinemaHall { get; set; }
    }    
}
