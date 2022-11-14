using FluentValidation;
using FilmReservation.Data.Data;
using FilmReservation.BusinessLogic.ViewModels.Authentication;

namespace FilmReservation.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        private readonly ApplicationDbContext _context;

        public RegisterRequestValidator(ApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.Email).NotNull().EmailAddress();
            RuleFor(x => x.Password).NotNull().Length(6, 100);
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password);           
        }
    }
}
