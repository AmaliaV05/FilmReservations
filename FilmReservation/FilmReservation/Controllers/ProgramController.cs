using FilmReservation.BusinessLogic.Interfaces;
using FilmReservation.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FilmReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private readonly IProgramService _programService;

        public ProgramController(IProgramService programService)
        {
            _programService = programService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPrograms()
        {
            return Ok(await _programService.GetPrograms());
        }

        [HttpGet("{idProgram}")]
        public async Task<IActionResult> GetProgram(int idProgram)
        {
            return Ok(await _programService.GetProgram(idProgram));
        }

        [HttpPost]
        [Authorize(Roles = "Admin", AuthenticationSchemes = "Identity.Application,Bearer")]
        public async Task<IActionResult> PostProgram(ProgramViewModel programViewModel)
        {
            var program = await _programService.AddProgram(programViewModel);
            return CreatedAtAction("GetProgram", new { id = program.Id }, program);
        }
    }
}
