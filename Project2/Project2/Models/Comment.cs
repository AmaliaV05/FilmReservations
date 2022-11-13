﻿using System.ComponentModel.DataAnnotations;

namespace FilmReservation.Models
{
    public class Comment
    {
        public long Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public bool Important { get; set; }
        public Film Film { get; set; }

        public Comment()
        {
        }

    }
}
