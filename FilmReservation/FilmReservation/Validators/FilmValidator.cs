using FluentValidation;
using FilmReservation.Data.Data;
using FilmReservation.BusinessLogic.ViewModels;
using System.Linq;

namespace FilmReservation.Validators
{
    public class FilmValidator : AbstractValidator<FilmViewModel>
    {
        private readonly ApplicationDbContext _context;

        public FilmValidator(ApplicationDbContext context)
        {
            _context = context;
            RuleFor(x => x.Description).MinimumLength(20);
            RuleFor(x => x.Rating).InclusiveBetween(1, 10);
            RuleFor(x => x.Genre).Custom((prop, validationContext) =>
            {
                var instance = validationContext.InstanceToValidate;
                int commentsForGenre = _context.Comments.Where(c => c.Film.Genre == instance.Genre).Count();
                if (commentsForGenre > 1000)
                {
                    validationContext.AddFailure($"Cannot add a film with genre {instance.Genre} because that genre has more than 1000 comments: it has {commentsForGenre}.");
                }
            });
        }
    }
}
