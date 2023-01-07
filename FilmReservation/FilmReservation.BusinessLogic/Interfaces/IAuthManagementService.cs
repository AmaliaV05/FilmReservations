using Microsoft.AspNetCore.Identity;
using FilmReservation.BusinessLogic.ViewModels.Authentication;
using System.Collections.Generic;
using System.Threading.Tasks;
using FilmReservation.BusinessLogic.Services;

namespace FilmReservation.BusinessLogic.Interfaces
{
    public interface IAuthManagementService
    {
        Task<ServiceResponse<RegisterResponse, IEnumerable<IdentityError>>> RegisterUser(RegisterRequest registerRequest);
        Task<bool> ConfirmUserRequest(ConfirmUserRequest confirmUserRequest);
        Task<ServiceResponse<LoginResponse, string>> LoginUser(LoginRequest loginRequest);
    }
}
