using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApotekApiAutoMapper.Controllers.Param
{
    public class ParamObatWithFotoDto
    {
        public string Kode { get; set; }
        public string Nama { get; set; }
        public int Stok { get; set; }
        public int? Harga { get; set; }
        public IFormFile Foto { get; set; }
    }
}
