using AutoMapper;
using FilmReservation.Data.Models;
using FilmReservation.BusinessLogic.ViewModels;
using FilmReservation.BusinessLogic.ViewModels.Reservations;

namespace FilmReservation
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Film, FilmViewModel>().ReverseMap();

            CreateMap<Reservation, ReservationForUserResponse>().ReverseMap();

            CreateMap<ApplicationUser, ApplicationUserViewModel>().ReverseMap();
        }
    }
}
