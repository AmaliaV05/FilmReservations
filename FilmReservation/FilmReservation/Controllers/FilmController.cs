using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FilmReservation.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Authorization;
using FilmReservation.HttpExtensions;
using FilmReservation.Data.Models.Pagination;
using FilmReservation.BusinessLogic.Interfaces;

namespace FilmReservation.Controllers
{
    [Authorize(AuthenticationSchemes = "Identity.Application,Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmService _filmService;
        private readonly ILogger<FilmController> _logger;

        public FilmController(IFilmService filmService, ILogger<FilmController> logger)
        {
            _filmService = filmService;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetFilms([FromQuery] FilmParams filmParams)
        {
            var films = await _filmService.GetFilms(filmParams);
            Response.AddPaginationHeader(films.CurrentPage, films.PageSize, films.TotalCount, films.TotalPages);
            return Ok(films.ToList());
        }

        [HttpGet("{idFilm}")]
        [Authorize(Roles = "Admin, Client")]
        public async Task<IActionResult> GetFilm(int idFilm)
        {
            return Ok(await _filmService.GetFilm(idFilm));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PostFilm(FilmViewModel filmViewModel)
        {
            var film = await _filmService.AddFilm(filmViewModel);
            return CreatedAtAction("GetFilm", new { id = film.Id }, film);
        }
    }
}
