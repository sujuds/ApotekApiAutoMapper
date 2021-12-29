using ApotekApiAutoMapper.DTOs;
using ApotekApiAutoMapper.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApotekApiAutoMapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObatController : Controller
    {
        private readonly IObatService _obatService;

        public ObatController(IObatService obatService)
        {
            _obatService = obatService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _obatService.GetObat();
            return new JsonResult(new { status = "success", data = result });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _obatService.GetObat(id);
            
            if (result == null) return new JsonResult(new { status = "error", message = "data tidak ditemukan!"});

            return new JsonResult(new { status = "success", data = result});
        }

        [HttpPost]
        public async Task<ActionResult> Add(ObatDto obat)
        {
            await _obatService.AddObat(obat);
            return new JsonResult(new
            {
                status = "success",
                message = "data berhasil ditambahkan!",
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, ObatDto obat)
        {
            await _obatService.EditObat(id, obat);
            return new JsonResult(new
            {
                status = "success",
                message = "data berhasil diubah!"
            });
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _obatService.DeleteObat(id);
            return new JsonResult(new
            {
                status = "success",
                message = "data berhasil dihapus!"
            });
        }
    }
}
