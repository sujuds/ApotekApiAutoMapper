using ApotekApiAutoMapper.DTOs;
using ApotekApiAutoMapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApotekApiAutoMapper.Services.Interface
{
    public interface ITransaksiService
    {
        Task<List<TransaksiDto>> GetTransaksi();
        Task<TransaksiDto> GetTransaksi(int transaksiId);
        Task<bool> AddTransaksi(TransaksiDto transaksiDto);
    }
}
