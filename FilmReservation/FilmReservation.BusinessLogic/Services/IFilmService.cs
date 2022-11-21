/*using FilmReservation.Data.Models;
using FilmReservation.Data.Models.Pagination;
using FilmReservation.BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FilmReservation.Data.Models.EnumUtils;

namespace FilmReservation.BusinessLogic.Services
{
    public interface IFilmService
    {
        Task<PagedList<Film>> GetAllFilms(FilmParams filmParams);
        Task<Film> GetFilmById(int id);
        IEnumerable<FilmViewModel> FilterFilms(DateTime firstDate, DateTime lastDate);
        IEnumerable<FilmViewModel> FilterFilmsByGenre(Genre genre);
        Task<bool> PutFilm(int id, FilmViewModel filmViewModel);
        Task<Film> PostFilm(FilmViewModel filmRequest);
        Task<bool> DeleteFilm(int id);
    }
}
*/