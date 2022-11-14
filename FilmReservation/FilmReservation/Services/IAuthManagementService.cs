using Microsoft.AspNetCore.Identity;
using FilmReservation.ViewModels.Authentication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmReservation.Services
{
    public interface IAuthManagementService
    {
        Task<ServiceResponse<RegisterResponse, IEnumerable<IdentityError>>> RegisterUser(RegisterRequest registerRequest);
        Task<bool> ConfirmUserRequest(ConfirmUserRequest confirmUserRequest);
        Task<ServiceResponse<LoginResponse, string>> LoginUser(LoginRequest loginRequest);
    }
}
