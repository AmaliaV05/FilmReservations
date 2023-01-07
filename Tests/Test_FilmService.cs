using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System;
using FilmReservation.Data.Data;
using FilmReservation.Data.Models;
using FilmReservation.Data.Models.EnumUtils;
using FilmReservation.BusinessLogic.Services;
using AutoMapper;
using FilmReservation;
using System.Threading.Tasks;
using FilmReservation.Data.Models.Pagination;
using FilmReservation.BusinessLogic.Exceptions;
using FilmReservation.BusinessLogic.ViewModels;

namespace Tests
{
    class Test_FilmService
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("In setup.");

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;
            _context = new ApplicationDbContext(options, new OperationalStoreOptionsForTests());
            var config = new MapperConfiguration(c => c.AddProfile<MappingProfile>());
            _mapper = config.CreateMapper();

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
            _context.SaveChanges();
        }

        [TearDown]
        public void Teardown()
        {
            Console.WriteLine("In teardown");
            foreach (var film in _context.Films)
            {
                _context.Remove(film);
            }
            _context.SaveChanges();
        }

        [Test]
        public async Task GetFilms_ShouldReturnAllFilms()
        {
            var service = new FilmService(_context, _mapper);
            var filmParams = new FilmParams();
            var actual = await service.GetFilms(filmParams);
            Assert.AreEqual(2, actual.Count);
        }

        [Test]
        public async Task GetFilmsWithSearch_ShouldReturnAllFilmsContainingSearchKeyword()
        {
            var service = new FilmService(_context, _mapper);            
            var filmParams = new FilmParams { Search = "Film1" };
            var actual = await service.GetFilms(filmParams);
            Assert.AreEqual(1, actual.Count);
        }

        [Test]
        public async Task GetFilmById_ShouldReturnCorrectFilm()
        {
            var service = new FilmService(_context, _mapper);
            var idFilm = 1;
            var actual = await service.GetFilm(idFilm);
            Assert.AreEqual("Film1 test", actual.Title);
        }

        [Test]
        public async Task WhenFilmDoesNotExist_ShouldThrowIdNotFoundException()
        {
            var service = new FilmService(_context, _mapper);
            var idFilm = 3;
            try
            {
                await service.GetFilm(idFilm);
            }
            catch (IdNotFoundException ex)
            {
                StringAssert.Contains(ex.Message, string.Format("There is no Film with id={0}", idFilm));
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }

        [Test]
        public async Task AddingAFilm_ShouldReturnCorrectFilm()
        {
            var service = new FilmService(_context, _mapper);
            var film = new FilmViewModel 
            {
                Title = "Film3 test",
                Description = "fsd ds fsd fsd",
                Genre = Genre.Fantasy,
                Duration = "1 h 15 min",
                YearOfRelease = DateTime.UtcNow.Year,
                Director = "Director3"
            };
            var actual = await service.AddFilm(film);
            Assert.AreEqual("Film3 test", actual.Title);
        }
    }
}
