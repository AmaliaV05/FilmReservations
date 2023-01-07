using System;
using System.Collections.Generic;

namespace FilmReservation.BusinessLogic.ViewModels.Reservations
{
    public class ReservationResponse
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public ApplicationUserViewModel ApplicationUser { get; set; }
        public ProgramViewModel Program { get; set; }
        public IEnumerable<SeatViewModel> Seats { get; set; }
    }

    public class SeatViewModel
    {
        public int Id { get; set; }
        public int SeatNumber { get; set; }
        public CinemaHallViewModel CinemaHall { get; set; }
    }
}
