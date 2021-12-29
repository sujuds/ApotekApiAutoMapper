using ApotekApiAutoMapper.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApotekApiAutoMapper.DbContexts
{
    public class AppDbContext : DbContext
    {

        public DbSet<Obat> Obats { get; set; }
        public DbSet<Transaksi> Transaksis { get; set; }
        public DbSet<TransaksiDetail> TransaksiDetails { get; set; }
        
        public AppDbContext( DbContextOptions options) : base(options)
        {
        }


    }
}
