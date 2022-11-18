using FluentValidation;
using FilmReservation.BusinessLogic.ViewModels;

namespace FilmReservation.Validators
{
    public class FilmValidator : AbstractValidator<FilmViewModel>
    {
        public FilmValidator()
        {
            RuleFor(x => x.Description).MinimumLength(20);            
        }
    }
}
