using AutoMapper;
using FilmReservation.Models;
using FilmReservation.ViewModels;
using FilmReservation.ViewModels.Reservations;

namespace FilmReservation
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Film, FilmViewModel>().ReverseMap();

            CreateMap<Comment, CommentViewModel>().ReverseMap();

            CreateMap<Film, FilmWithCommentViewModel>().ReverseMap();

            CreateMap<Reservation, ReservationForUserResponse>().ReverseMap();

            CreateMap<ApplicationUser, ApplicationUserViewModel>().ReverseMap();
        }
    }
}
