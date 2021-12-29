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
    public class TransaksiService : ITransaksiService
    {
        private readonly AppDbContext _contex;
        private readonly IMapper _mapper;

        public TransaksiService(AppDbContext context, IMapper mapper)
        {
            _contex = context;
            _mapper = mapper;
        }

        public async Task<bool> AddTransaksi(TransaksiDto transaksiDto)
        {
            await _contex.Transaksis.AddAsync(_mapper.Map<Transaksi>(transaksiDto));
            var createRowCount = await _contex.SaveChangesAsync();
            return createRowCount > 0;
        }

        public async Task<List<TransaksiDto>> GetTransaksi()
        {
            var transaksi = await _contex.Transaksis
                                .Include(t => t.TransaksiDetails)
                                .Select(t => new Transaksi()
                                {
                                    Id = t.Id,
                                    Kode = t.Kode,
                                    Total = t.Total,
                                    TransaksiDetails = t.TransaksiDetails.Select(td => new TransaksiDetail
                                    {
                                        Id = td.Id,
                                        Jumlah = td.Jumlah,
                                        Obat = td.Obat
                                    })
                                })
                                .ToListAsync();
            return _mapper.Map<List<TransaksiDto>>(transaksi);
        }

        public async Task<TransaksiDto> GetTransaksi(int transaksiId)
        {

            var transaksi = await _contex.Transaksis
                                .Include(t => t.TransaksiDetails)
                                .Select( t => new Transaksi() {
                                    Id = t.Id,
                                    Kode = t.Kode,
                                    Total = t.Total,
                                    TransaksiDetails = t.TransaksiDetails.Select( td => new TransaksiDetail { 
                                        Id = td.Id,
                                        Jumlah = td.Jumlah,
                                        Obat = td.Obat
                                    })
                                })
                                .SingleOrDefaultAsync(t => t.Id == transaksiId);

            return _mapper.Map<TransaksiDto>(transaksi);
        }
    }
}
