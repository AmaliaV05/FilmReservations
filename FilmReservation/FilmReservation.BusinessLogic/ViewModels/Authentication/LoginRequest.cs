﻿namespace FilmReservation.BusinessLogic.ViewModels.Authentication
{
    public class LoginRequest
    {
        /*[Required]
        [EmailAddress]*/
        public string Email { get; set; }

        /*[Required]
        [DataType(DataType.Password)]*/
        public string Password { get; set; }
    }
}
