using AutoMapper;
using FilmReservation.BusinessLogic.Interfaces;
using FilmReservation.BusinessLogic.ViewModels.Reservations;
using FilmReservation.Data.Data;
using FilmReservation.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FilmReservation.BusinessLogic.Services
{
    public class ReservationService : IReservationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReservationService(ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IEnumerable<ReservationResponse>> GetReservations(IEnumerable<Claim> claims)
        {
            var currentLoggedInUser = claims.Where(c => c.Type == "userName").FirstOrDefault().Value;
            return await _context.Reservations
                .OrderByDescending(r => r.Id)
                .Where(r => r.ApplicationUser.UserName == currentLoggedInUser)
                .Select(r => _mapper.Map<ReservationResponse>(r))
                .ToListAsync();
        }

        public async Task<ServiceResponse<ReservationResponse, string>> GetReservation(IEnumerable<Claim> claims, int idReservation)
        {
            var currentLoggedInUser = claims.Where(c => c.Type == "userName").FirstOrDefault().Value;
            var serviceResponse = new ServiceResponse<ReservationResponse, string>();
            var reservation = await _context.Reservations
                .Where(r => r.ApplicationUser.UserName == currentLoggedInUser && r.Id == idReservation)
                .Select(r => _mapper.Map<ReservationResponse>(r))
                .FirstOrDefaultAsync();
            if (reservation == null)
            {
                serviceResponse.ResponseError = "The reservation does not exist";
            }
            serviceResponse.ResponseOk = reservation;
            return serviceResponse;
        }

        public async Task<ServiceResponse<ReservationResponse, string>> AddReservation(IEnumerable<Claim> claims, NewReservationRequest reservationRequest)
        {
            var currentLoggedInUser = claims.Where(c => c.Type == "userName").FirstOrDefault().Value;
            var serviceResponse = new ServiceResponse<ReservationResponse, string>();
            var seatsToReserve = new List<Seat>();
            reservationRequest.SeatsIds.ForEach(sid =>
            {
                var checkSeat = _context.Seats.Find(sid);
                if (checkSeat != null && checkSeat.Occupied == false)
                {
                    seatsToReserve.Add(checkSeat);
                }
            });
            if (seatsToReserve.Count < reservationRequest.SeatsIds.Count)
            {
                var occupiedSeats = reservationRequest.SeatsIds.Count - seatsToReserve.Count;
                serviceResponse.ResponseError = string.Format("{0} seats are already occupied", occupiedSeats);
                return serviceResponse;
            }
            var reservation = new Reservation
            {                
                DateTime = DateTime.UtcNow,
                ApplicationUser = await _userManager.FindByNameAsync(currentLoggedInUser),
                Program = _mapper.Map<Program>(reservationRequest.Program),
                Seats = seatsToReserve
            };
            _context.Reservations.Add(reservation);
            await SaveChangesAsync();
            serviceResponse.ResponseOk = _mapper.Map<ReservationResponse>(reservation);
            return serviceResponse;
        }

        private async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;
    }
}
