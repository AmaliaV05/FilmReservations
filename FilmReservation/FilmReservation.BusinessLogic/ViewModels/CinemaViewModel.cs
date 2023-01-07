namespace FilmReservation.BusinessLogic.ViewModels
{
    public class CinemaHallViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CinemaViewModel Cinema { get; set; }
    }

    public class CinemaViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
