using ApotekApiAutoMapper.DTOs;
using ApotekApiAutoMapper.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApotekApiAutoMapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaksiController : Controller
    {
        private readonly ITransaksiService _transaksiService;

        public TransaksiController(ITransaksiService transaksiService)
        {
            _transaksiService = transaksiService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _transaksiService.GetTransaksi();
            return new JsonResult(new { status = "success", data = result });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _transaksiService.GetTransaksi(id);

            if (result == null) return new JsonResult(new { status = "error", message = "data tidak ditemukan!" });

            return new JsonResult(new { status = "success", data = result });
        }


        [HttpPost]
        public async Task<ActionResult> Add(TransaksiDto transaksi)
        {
            await _transaksiService.AddTransaksi(transaksi);
            return new JsonResult(new
            {
                status = "success",
                message = "data berhasil ditambahkan!",
            });
        }
    }
}
