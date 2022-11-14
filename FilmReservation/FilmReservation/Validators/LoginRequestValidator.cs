﻿using FluentValidation;
using FilmReservation.Data.Data;
using FilmReservation.BusinessLogic.ViewModels.Authentication;

namespace FilmReservation.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        private readonly ApplicationDbContext _context;

        public LoginRequestValidator(ApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.Email).NotNull().EmailAddress();
            RuleFor(x => x.Password).NotNull();
        }
    }
}
