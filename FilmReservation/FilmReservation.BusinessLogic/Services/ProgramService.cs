using AutoMapper;
using FilmReservation.BusinessLogic.Exceptions;
using FilmReservation.BusinessLogic.Interfaces;
using FilmReservation.BusinessLogic.ViewModels;
using FilmReservation.Data.Data;
using FilmReservation.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmReservation.BusinessLogic.Services
{
    public class ProgramService : IProgramService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProgramService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProgramViewModel>> GetPrograms()
        {
            return await _context.Programs
                .Where(p => p.DateTime >= DateTime.UtcNow)
                .Include(p => p.Film)
                .Select(p => _mapper.Map<ProgramViewModel>(p))
                .ToListAsync();
        }

        public async Task<ProgramViewModel> GetProgram(int idProgram)
        {
            var program = await _context.Programs
                .Where(p => p.Id == idProgram)
                .FirstOrDefaultAsync();
            if (program == null)
            {
                throw new IdNotFoundException();
            }
            return _mapper.Map<ProgramViewModel>(program);
        }

        public async Task<ProgramViewModel> AddProgram(ProgramViewModel programViewModel)
        {
            var program = _mapper.Map<Program>(programViewModel);
            _context.Programs.Add(program);
            await SaveChangesAsync();
            return _mapper.Map<ProgramViewModel>(program);
        }

        private async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;
    }
}
