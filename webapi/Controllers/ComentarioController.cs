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

    public class ComentarioController : ControllerBase
    {
        private readonly BdContext _context;

        public ComentarioController(BdContext context)
        {
            _context = context;
        }

        //Read Comentarios
        [HttpGet]
        public IEnumerable<Comentario> GetComentarios()
        {
            return _context.Comentarios;
        }

        //Read Comentario
        [HttpGet("{id}")]
        public async Task<ActionResult<Comentario>> GetComentario(int idCom)
        {
            Comentario comentario = await _context.Comentarios.FindAsync(idCom);

            if (comentario == null)
            {
                return NotFound();
            }

            return comentario;
        }

        //Create Comentario
        [HttpPost]
        public async Task<ActionResult<Comentario>> CreateComentario(Comentario comentario)
        {
            _context.Comentarios.Add(comentario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComentario", new { idComentario = comentario.idComentario }, comentario);
        }

        private Boolean FindComentario(int idCom)
        {
            return _context.Comentarios.Any(c => c.idComentario == idCom);
        }

        //Update Comentario
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComentario(int idCom, Comentario comentario)
        {
            if (idCom!= comentario.idComentario)
            {
                return NotFound();
            }

            _context.Entry(comentario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                if (!FindComentario(idCom))
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

        //Delete Comentario
        [HttpDelete("{id}")]
        public async Task<ActionResult<Comentario>> DeleteComentario(int idCom)
        {
            var comentario = await _context.Comentarios.FindAsync(idCom);
            if (comentario == null)
            {
                return NotFound();
            }

            _context.Comentarios.Remove(comentario);
            await _context.SaveChangesAsync();

            return comentario;
        }
    }
}
