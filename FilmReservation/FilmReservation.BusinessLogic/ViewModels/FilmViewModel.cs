using FilmReservation.Data.Models.EnumUtils;
using System;

namespace FilmReservation.BusinessLogic.ViewModels
{
    public class FilmViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public string Duration { get; set; }
        public int YearOfRelease { get; set; }
        public string Cast { get; set; }
        public string Director { get; set; }
        public Language Language { get; set; }
        public AgeRestriction AgeRestriction { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
