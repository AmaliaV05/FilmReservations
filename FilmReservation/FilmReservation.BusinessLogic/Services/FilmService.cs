using Microsoft.EntityFrameworkCore;
using FilmReservation.Data.Data;
using FilmReservation.BusinessLogic.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using FilmReservation.Data.Models.Pagination;
using FilmReservation.Data.Models;
using AutoMapper;
using FilmReservation.BusinessLogic.Exceptions;
using FilmReservation.BusinessLogic.Interfaces;

namespace FilmReservation.BusinessLogic.Services
{
    public class FilmService : IFilmService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FilmService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedList<FilmViewModel>> GetFilms(FilmParams filmParams)
        {
            var query = _context.Films.AsQueryable();
            query = Search(query, filmParams);
            return await PagedList<FilmViewModel>.CreateAsync(query.AsNoTracking().Select(f => _mapper.Map<FilmViewModel>(f)),
                filmParams.PageNumber, filmParams.PageSize);
        }

        private static IQueryable<Film> Search(IQueryable<Film> query, FilmParams filmParams)
        {
            if (!string.IsNullOrEmpty(filmParams.Search))
            {
                return query.Where(q => q.Title.ToLower().Contains(filmParams.Search.ToLower()));
            }
            return query;
        }

        public async Task<FilmViewModel> GetFilm(int idFilm)
        {
            var film = await _context.Films
                .Where(b => b.Id == idFilm)                
                .FirstOrDefaultAsync();
            if (film == null)
            {
                throw new IdNotFoundException(nameof(Film), idFilm);
            }
            return _mapper.Map<FilmViewModel>(film);
        }

        public async Task<FilmViewModel> AddFilm(FilmViewModel filmViewModel)
        {            
            var film = _mapper.Map<Film>(filmViewModel);
            _context.Films.Add(film);
            await SaveChangesAsync();
            return _mapper.Map<FilmViewModel>(film);
        }

        private async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;
    }
}
