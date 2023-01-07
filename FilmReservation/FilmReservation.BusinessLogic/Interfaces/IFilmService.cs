using FilmReservation.Data.Models.Pagination;
using FilmReservation.BusinessLogic.ViewModels;
using System.Threading.Tasks;

namespace FilmReservation.BusinessLogic.Interfaces
{
    public interface IFilmService
    {
        Task<PagedList<FilmViewModel>> GetFilms(FilmParams filmParams);
        Task<FilmViewModel> GetFilm(int id);
        Task<FilmViewModel> AddFilm(FilmViewModel filmViewModel);
    }
}
