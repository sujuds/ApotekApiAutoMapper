using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApotekApiAutoMapper.DTOs
{
    public class ObatDto
    {
        public int Id { get; set; }
        public string Kode { get; set; }
        public string Nama { get; set; }
        public int Stok { get; set; }
        public int? Harga { get; set; }
    }
}
