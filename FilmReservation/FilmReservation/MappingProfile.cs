using AutoMapper;
using FilmReservation.BusinessLogic.ViewModels;
using FilmReservation.BusinessLogic.ViewModels.Reservations;
using FilmReservation.Data.Models;

namespace FilmReservation
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Film, FilmViewModel>().ReverseMap();
            
            CreateMap<Data.Models.Program, ProgramViewModel>().ReverseMap();
            CreateMap<Cinema, CinemaViewModel>().ReverseMap();
            CreateMap<CinemaHall, CinemaHallViewModel>().ReverseMap();

            CreateMap<Reservation, ReservationResponse>().ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserViewModel>().ReverseMap();
            CreateMap<Seat, SeatViewModel>().ReverseMap();
        }
    }
}
