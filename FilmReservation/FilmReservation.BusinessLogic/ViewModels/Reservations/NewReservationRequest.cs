using System;
using System.Collections.Generic;

namespace FilmReservation.BusinessLogic.ViewModels.Reservations
{
    public class NewReservationRequest
    {
        public List<int> ReservedFilmsIds { get; set; }
        public DateTime? ReservationDateTime { get; set; }
    }
}
