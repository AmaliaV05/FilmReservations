﻿using System.Collections.Generic;

namespace FilmReservation.ViewModels
{
    public class ApplicationUserViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }

        public IList<string> UserRoles { get; set; } = new List<string>();
    }
}
