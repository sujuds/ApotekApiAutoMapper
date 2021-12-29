using ApotekApiAutoMapper.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApotekApiAutoMapper.Services.Interface
{
    public interface IObatService
    {
        Task<List<ObatDto>> GetObat();
        Task<ObatDto> GetObat(int obatId);
        Task<bool> AddObat(ObatDto obatDto);
        Task<bool> EditObat(int obatId, ObatDto obatDto);
        Task<bool> DeleteObat(int obatId);
    }
}
