using System.Collections.Generic;

namespace FilmReservation.BusinessLogic.ViewModels.Reservations
{
    public class NewReservationRequest
    {
        public ApplicationUserViewModel ApplicationUser { get; set; }
        public ProgramViewModel Program { get; set; }
        public List<int> SeatsIds { get; set; }
    }
}
