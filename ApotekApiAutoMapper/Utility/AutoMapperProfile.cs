using ApotekApiAutoMapper.DTOs;
using ApotekApiAutoMapper.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApotekApiAutoMapper.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ObatDto, Obat>().ReverseMap();
            CreateMap<TransaksiDto, Transaksi>().ReverseMap();
            CreateMap<TransaksiDetailDto, TransaksiDetail>().ReverseMap();

            //CreateMap<ObatDto, Obat>()
            //    .ForMember(o => o.Id, opt => opt.MapFrom(src => src.IdObat))
            //    .ForMember(o => o.Kode, opt => opt.MapFrom(src => src.KodeObat));
        }
    }
}
