using System;
using System.Collections.Generic;

namespace FilmReservation.ViewModels.Reservations
{
    public class ReservationForUserResponse
    {
        public ApplicationUserViewModel ApplicationUser { get; set; }
        public List<FilmViewModel> Films { get; set; }
        public DateTime ReservationDateTime { get; set; }
    }
}
