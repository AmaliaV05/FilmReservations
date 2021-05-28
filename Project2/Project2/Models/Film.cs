﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public class Film
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public enum Genre { Action, Comedy, Horror, Thriller }
        [Required]
        public string Duration { get; set; }
        public int YearOfRelease { get; set; }
        [Required]
        public string Director { get; set; }
        public DateTime DateAdded { get; set; }
        [Range(1,10)]
        public int Rating { get; set; }
        [Required]
        public string Watched { get; set; }
    }
}