using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FilmReservation.Data.Models;
using FilmReservation.BusinessLogic.ViewModels.Reservations;
using System.Security.Claims;
using System.Threading.Tasks;
using FilmReservation.BusinessLogic.Interfaces;

namespace FilmReservation.Controllers
{
    [Authorize(AuthenticationSchemes = "Identity.Application,Bearer")]
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly ILogger<ReservationController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReservationController(IReservationService reservationService, ILogger<ReservationController> logger, UserManager<ApplicationUser> userManager)
        {
            _reservationService = reservationService;
            _logger = logger;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> GetReservations()
        {
            var claims = (User.Identity as ClaimsIdentity).Claims;
            return Ok(await _reservationService.GetReservations(claims));
        }

        [HttpGet("{idReservation}")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> GetReservations(int idReservation)
        {
            var claims = (User.Identity as ClaimsIdentity).Claims;
            return Ok(await _reservationService.GetReservation(claims, idReservation));
        }

        [HttpPost]
        [Authorize(Roles = "Client")]
        public async Task<ActionResult> MakeReservation(NewReservationRequest reservationRequest)
        {
            var claims = (User.Identity as ClaimsIdentity).Claims;
            return Ok(await _reservationService.AddReservation(claims, reservationRequest));
        }
    }
}
