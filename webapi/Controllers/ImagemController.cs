using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Context;
using webapi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ImagemController : ControllerBase
    {
        private readonly BdContext _context;

        public ImagemController(BdContext context)
        {
            _context = context;
        }

        //Read Imagens
        [HttpGet]
        public IEnumerable<Imagem> GetImagens()
        {
            return _context.Imagems;
        }

        //Read Imagem
        [HttpGet("{id}")]
        public async Task<ActionResult<Imagem>> GetReserva(int idImg)
        {
            Imagem imagem = await _context.Imagems.FindAsync(idImg);

            if (imagem == null)
            {
                return NotFound();
            }

            return imagem;
        }

        //Create Imagem
        [HttpPost]
        public async Task<ActionResult<Imagem>> CreateReserva(Imagem imagem)
        {
            _context.Imagems.Add(imagem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImagem", new { idImagem = imagem.idImagem }, imagem);
        }

        private Boolean FindImagem(int idImg)
        {
            return _context.Imagems.Any(i => i.idImagem == idImg;
        }

        //Update Imagem
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateImagem(int idImg, Imagem imagem)
        {
            if (idImg != imagem.idImagem)
            {
                return NotFound();
            }

            _context.Entry(imagem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                if (!FindImagem(idImg))
                {
                    return NotFound();
                }
                else
                {
                    throw new Exception();
                }

            }

            return NoContent();
        }

        //Delete Imagem
        [HttpDelete("{id}")]
        public async Task<ActionResult<Imagem>> DeleteImagem(int idImg)
        {
            var imagem = await _context.Imagems.FindAsync(idImg);
            if (imagem == null)
            {
                return NotFound();
            }

            _context.Imagems.Remove(imagem);
            await _context.SaveChangesAsync();

            return imagem;
        }

    }
}
