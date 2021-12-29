using ApotekApiAutoMapper.DbContexts;
using ApotekApiAutoMapper.DTOs;
using ApotekApiAutoMapper.Model;
using ApotekApiAutoMapper.Services.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApotekApiAutoMapper.Services
{
    public class ObatService : IObatService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ObatService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddObat(ObatDto obatDto)
        {
            await _context.Obats.AddAsync(_mapper.Map<Obat>(obatDto));
            var createdRowCount = await _context.SaveChangesAsync();

            return createdRowCount > 0;
        }

        public async Task<bool> DeleteObat(int obatId)
        {
            var obat = await _context.Obats.SingleOrDefaultAsync(o => o.Id == obatId);

            _context.Obats.Remove(_mapper.Map<Obat>(obat));
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditObat(int obatId, ObatDto obatDto)
        {
            obatDto.Id = obatId;
            _context.Entry(_mapper.Map<Obat>(obatDto)).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<ObatDto>> GetObat()
        {
            var obat = await _context.Obats.ToListAsync();
            return _mapper.Map<List<ObatDto>>(obat);
        }

        public async Task<ObatDto> GetObat(int obatId)
        {
            var obat = await _context.Obats.SingleOrDefaultAsync(o => o.Id == obatId);
            return _mapper.Map<ObatDto>(obat);
        }
    }
}
