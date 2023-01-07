using FilmReservation.BusinessLogic.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmReservation.BusinessLogic.Interfaces
{
    public interface IProgramService
    {
        Task<IEnumerable<ProgramViewModel>> GetPrograms();
        Task<ProgramViewModel> GetProgram(int idProgram);
        Task<ProgramViewModel> AddProgram(ProgramViewModel programViewModel);
    }
}
