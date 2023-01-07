using FilmReservation.Data.Data;
using FilmReservation.Data.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace FilmReservation.Data.Configuration
{
    public class SeedData
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();
            var cinemas = AddCinemas(context);
            var cinemaHalls = AddCinemaHalls(context, cinemas);
            AddSeats(context, cinemaHalls);
            context.SaveChanges();            
        }

        private static List<Cinema> AddCinemas(ApplicationDbContext context)
        {
            var cinemas = new List<Cinema> {
                new Cinema { Name = "Cinema1", TotalHalls = 3 },
                new Cinema { Name = "Cinema2", TotalHalls = 4 },
                new Cinema { Name = "Cinema3", TotalHalls = 3 }
            };
            context.Cinemas.AddRange(cinemas);
            return cinemas;
        }

        private static List<CinemaHall> AddCinemaHalls(ApplicationDbContext context, List<Cinema> cinemas)
        {
            var totalSeats = new List<int> { 60, 70, 80 };
            var random = new Random();

            var cinemaHalls = new List<CinemaHall>();
            foreach (var cinema in cinemas)
            {
                for (int i = 1; i <= cinema.TotalHalls; i++)
                {
                    cinemaHalls.Add(new CinemaHall
                    {
                        Name = string.Format("Hall{0}", i),
                        TotalSeats = totalSeats[random.Next(totalSeats.Count)],
                        Cinema = cinema
                    });
                }
            }
            context.CinemaHalls.AddRange(cinemaHalls);
            return cinemaHalls;
        }

        private static void AddSeats(ApplicationDbContext context, List<CinemaHall> cinemaHalls)
        {
            var seats = new List<Seat>();
            foreach (var cinemaHall in cinemaHalls)
            {
                for (int i = 1; i <= cinemaHall.TotalSeats; i++)
                {
                    seats.Add(new Seat
                    {
                        SeatNumber = i,
                        Occupied = false,
                        CinemaHall = cinemaHall
                    });
                }
            }
            context.Seats.AddRange(seats);
        }
    }
}
