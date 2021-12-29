using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApotekApiAutoMapper.DTOs
{
    public class TransaksiDto
    {
        public int Id { get; set; }
        public string Kode { get; set; }
        public int Total { get; set; }
        public IEnumerable<TransaksiDetailDto> TransaksiDetails { get; set; }
    }

    public class TransaksiDetailDto
    {
        public int Id { get; set; }
        public int? TransaksiId { get; set; }
        public int? ObatId { get; set; }
        public int Jumlah { get; set; }
        public TransaksiDto Transaksi { get; set; }
        public ObatDto Obat { get; set; }
    }
}
