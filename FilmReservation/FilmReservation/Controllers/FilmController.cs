using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using FilmReservation.Data.Data;
using FilmReservation.Data.Models;
using FilmReservation.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Authorization;
using FilmReservation.BusinessLogic.Services;
using FilmReservation.HttpExtensions;
using FilmReservation.Data.Models.Pagination;
using FilmReservation.Data.Models.EnumUtils;

namespace FilmReservation.Controllers
{
    [Authorize(AuthenticationSchemes = "Identity.Application,Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private IFilmService _filmService;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<FilmController> _logger;
        

        public FilmController(IFilmService filmService, ApplicationDbContext context, IMapper mapper, ILogger<FilmController> logger)
        {
            _filmService = filmService;
            _context = context;
            _mapper = mapper;
            _logger = logger;            
        }

        /// <summary>
        /// Get all films
        /// </summary>
        /// <returns>Returns all films</returns>
        // GET: api/Film
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Film>>> GetFilms([FromQuery]FilmParams filmParams)
        {
            //var title = await _filmService.FilterFilmsByTitle(Film.);
            //filmParams.Title = _

            var films = await _filmService.GetAllFilms(filmParams);

            Response.AddPaginationHeader(films.CurrentPage, films.PageSize, films.TotalCount, films.TotalPages);

            return films.ToList();
        }

        /// <summary>
        /// Get film by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns film by id</returns>
        // GET: api/Film/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<FilmViewModel>> GetFilm(int id)
        {
            var film = await _context.Films.FindAsync(id);

            if (film == null)
            {
                return NotFound();
            }

            var filmViewModel = _mapper.Map<FilmViewModel>(film);

            return filmViewModel;
        }

        /// <summary>
        /// Get all films by a specific genre
        /// </summary>
        /// <param name="genre"></param>
        /// <returns>All films by a specific genre in descending order by year of release</returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("filter-genre/{genre}")]
        public ActionResult<IEnumerable<FilmViewModel>> FilterFilmsByGenre(Genre genre)
        {
            var filmViewModelList = _context.Films.Select(film => _mapper.Map<FilmViewModel>(film)).ToList();

            var filmListSorted = filmViewModelList.Where(film => film.Genre == genre).ToList();

            return filmListSorted.OrderByDescending(film => film.YearOfRelease).ToList();
        }

        /// <summary>
        /// Update a film by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="filmViewModel"></param>
        /// <returns>Does not show any return value</returns>
        // PUT: api/Film/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilm(int id, FilmViewModel filmViewModel)
        {
            var film = _mapper.Map<Film>(filmViewModel);

            if (id != film.Id)
            {
                return BadRequest();
            }

            _context.Entry(film).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }    

        /// <summary>
        /// Create a new film entry
        /// </summary>
        /// <param name="filmRequest"></param>
        /// <returns>Returns the new film entry</returns>
        // POST: api/Film
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FilmViewModel>> PostFilm(FilmViewModel filmRequest)
        {
            Film film = _mapper.Map<Film>(filmRequest);
            _context.Films.Add(film);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilm", new { id = film.Id }, film);
        }        

        /// <summary>
        /// Delete a film by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Film/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilm(int id)
        {
            var film = await _context.Films.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }

            _context.Films.Remove(film);
            await _context.SaveChangesAsync();

            return NoContent();
        }       

        private bool FilmExists(int id)
        {
            return _context.Films.Any(e => e.Id == id);
        }
    }
}
