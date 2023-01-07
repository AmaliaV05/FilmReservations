using FilmReservation.BusinessLogic.Services;
using FilmReservation.BusinessLogic.ViewModels.Reservations;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FilmReservation.BusinessLogic.Interfaces
{
    public interface IReservationService
    {
        Task<IEnumerable<ReservationResponse>> GetReservations(IEnumerable<Claim> claims);
        Task<ServiceResponse<ReservationResponse, string>> GetReservation(IEnumerable<Claim> claims, int idReservation);
        Task<ServiceResponse<ReservationResponse, string>> AddReservation(IEnumerable<Claim> claims, NewReservationRequest reservationRequest);
    }
}
