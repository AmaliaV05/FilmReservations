/*using Microsoft.EntityFrameworkCore;
using FilmReservation.Data.Data;
using FilmReservation.BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmReservation.Data.Models.Pagination;
using FilmReservation.Data.Models;
using FilmReservation.Data.Models.EnumUtils;

namespace FilmReservation.BusinessLogic.Services
{
    public class FilmService : IFilmService
    {
        public ApplicationDbContext _context;

        public FilmService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedList<Film>> GetAllFilms(FilmParams filmParams)
        {
           var query = _context.Films.AsQueryable();

           if (!String.IsNullOrEmpty(filmParams.Title))
           {
               query = query.Where(f => f.Title == filmParams.Title);
           }

           return await PagedList<Film>.CreateAsync(query.AsNoTracking(),
               filmParams.PageNumber, filmParams.PageSize);
        }

        public Task<Film> GetFilmById(int id)
        {
            throw new NotImplementedException();
        }        

        public IEnumerable<FilmViewModel> FilterFilms(DateTime firstDate, DateTime lastDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FilmViewModel> FilterFilmsByGenre(Genre genre)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutFilm(int id, FilmViewModel filmViewModel)
        {
            throw new NotImplementedException();
        }        

        public Task<Film> PostFilm(FilmViewModel filmRequest)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFilm(int id)
        {
            throw new NotImplementedException();
        }
    }
}
*/