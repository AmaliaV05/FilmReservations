using AutoMapper;
using FilmReservation;
using FilmReservation.BusinessLogic.Services;
using FilmReservation.Data.Data;
using FilmReservation.Data.Models;
using FilmReservation.Data.Models.EnumUtils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Tests
{
    class Test_ReservationService
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;
        private UserManager<ApplicationUser> _userManager;

        [SetUp]
        public async Task Setup()
        {
            Console.WriteLine("In setup.");

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;
            _context = new ApplicationDbContext(options, new OperationalStoreOptionsForTests());
            var config = new MapperConfiguration(c => c.AddProfile<MappingProfile>());
            _mapper = config.CreateMapper();
            //_userManager = new UserManager<ApplicationUser>();

            _context.Films.AddRange(new Film[]
            {
                new Film
                {
                    Id = 1,
                    Title = "Film1 test",
                    Description = "fsd ds fsd fsd",
                    Genre = Genre.Action,
                    Duration = "2 h 5 min",
                    YearOfRelease = DateTime.UtcNow.Year,
                    Director = ""
                },
                new Film
                {
                    Id = 2,
                    Title = "Film2 test",
                    Description = "dfs sd sd fsd",
                    Genre = Genre.Comedy,
                    Duration = "2 h",
                    YearOfRelease = DateTime.UtcNow.Year,
                    Director = ""
                }
            });
            var cinema = new Cinema { Id = 1, Name = "Cinema1", TotalHalls = 3 };
            _context.Cinemas.Add(cinema);

            var cinemaHalls = new List<CinemaHall>();            
            for (int i = 1; i <= cinema.TotalHalls; i++)
            {
                cinemaHalls.Add(new CinemaHall
                {
                    Id = i,
                    Name = string.Format("Hall{0}", i),
                    TotalSeats = 60,
                    Cinema = cinema
                });
            }            
            _context.CinemaHalls.AddRange(cinemaHalls);

            var seats = new List<Seat>();
            int seatId = 1;
            foreach (var cinemaHall in cinemaHalls)
            {
                for (int i = 1; i <= cinemaHall.TotalSeats; i++)
                {
                    seats.Add(new Seat
                    {
                        Id = seatId,
                        SeatNumber = i,
                        Occupied = false,
                        CinemaHall = cinemaHall
                    });
                    seatId++;
                }
            }
            _context.Seats.AddRange(seats);            
            AddRoles();
            await AddUser();
            _context.SaveChanges();
        }

        private void AddRoles()
        {
            _context.Roles.AddRange(new IdentityRole[] 
            {
                new IdentityRole
                {
                    Id = "a28e507a-b8ed-4f27-be42-f07ffd95d67a",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "e31c1f63-ddcf-4bea-a742-927c29ca95a5"
                },
                new IdentityRole
                {
                    Id = "cc6217b2-d274-4b5f-8889-aa31af5e488e",
                    Name = "Client",
                    NormalizedName = "CLIENT",
                    ConcurrencyStamp = "8bd93dc9-8e68-4e63-abbd-50be08232fee"
                }
            });
        }

        private async Task AddUser()
        {
            var user = new ApplicationUser
            {
                Id = "f0e5116a-a588-40ed-a5da-1c28d801d124",
                UserName = "client1@email.com",
                Email = "client1@email.com",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var password = user.Email;
            await _userManager.CreateAsync(user, password);
            await _userManager.AddToRoleAsync(user, "Client");
        }

        [TearDown]
        public void Teardown()
        {
            Console.WriteLine("In teardown");
            foreach (var film in _context.Films)
            {
                _context.Remove(film);
            }
            foreach (var seat in _context.Seats)
            {
                _context.Remove(seat);
            }
            foreach (var cinemaHall in _context.CinemaHalls)
            {
                _context.Remove(cinemaHall);
            }
            foreach (var cinema in _context.Cinemas)
            {
                _context.Remove(cinema);
            }
            _context.SaveChanges();
        }

        [Test]
        public async Task Test()
        {
            var service = new ReservationService(_context, _mapper, _userManager);

            var currentUser = new ApplicationUser
            {
                UserName = "client1@email.com",
                Email = "client1@email.com"
            };

            var claims = new List<Claim>
            {
                new Claim("userName", currentUser.UserName)
            };
            var roles = await _userManager.GetRolesAsync(currentUser);
            claims.AddRange(roles.Select(role => new Claim("role", role)));
            
            var actual = await service.GetReservations(claims);
            Assert.AreEqual(2, actual.Count());
        }
    }    
}
