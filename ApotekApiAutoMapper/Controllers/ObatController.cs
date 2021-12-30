using ApotekApiAutoMapper.Controllers.Param;
using ApotekApiAutoMapper.DTOs;
using ApotekApiAutoMapper.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> Add([FromForm] ParamObatWithFotoDto param)
        {
            string fileName = UploadFile(param.Foto).Result.ToString();

            await _obatService.AddObat(new ObatDto { 
                Kode = param.Kode,
                Harga = param.Harga,
                Nama = param.Nama,
                Stok = param.Stok,
                Foto = fileName
            });


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



        private async Task<string> UploadFile(IFormFile file)
        {
            string fileName;
            string result = null;
            try
            {
                var folderName = Path.Combine("Storage", "Obat");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                fileName = DateTime.Now.Ticks + extension;

                result = fileName;

                var fullPath = Path.Combine(pathToSave, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

            }
            catch (Exception)
            {
                //log error
            }

            return result;
        }
    }
}
