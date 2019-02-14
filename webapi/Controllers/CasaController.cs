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

    public class CasaController : ControllerBase
    {
        private readonly BdContext _context;

        public CasaController(BdContext context)
        {
            _context = context;
        }

        //Read Casas
        [HttpGet]
        public IEnumerable<Casa> GetCasas()
        {
            return _context.Casas;
        }

        //Read Casa
        [HttpGet("{id}")]
        public async Task<ActionResult<Casa>> GetCasa(int idCasa)
        {
            Casa casa = await _context.Casas.FindAsync(idCasa);

            if (casa == null)
            {
                return NotFound();
            }

            return casa;
        }

        //Create Casa
        [HttpPost]
        public async Task<ActionResult<Casa>> CreateCasa(Casa casa)
        {
            _context.Casas.Add(casa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCasa", new { idCasa = casa.idCasa }, casa);
        }

        private Boolean FindCasa(int idCas)
        {
            return _context.Casas.Any(c => c.idCasa == idCas);
        }

        //Update Casa
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCasa(int idCas, Casa casa)
        {
            if (idCas != casa.idCasa)
            {
                return NotFound();
            }

            _context.Entry(casa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                if (!FindCasa(idCas))
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

        //Delete Casa
        [HttpDelete("{id}")]
        public async Task<ActionResult<Casa>> DeleteCasa(int idCas)
        {
            var casa = await _context.Casas.FindAsync(idCas);
            if (casa == null)
            {
                return NotFound();
            }

            _context.Casas.Remove(casa);
            await _context.SaveChangesAsync();

            return casa;
        }

        [HttpGet("{id}/quartos")]
        public IEnumerable<Quarto> GetQuartosCasa(int idCas)
        {
            var quartos = from q in _context.Quartos
                          join c in _context.Casas on q.idCasa equals c.idCasa
                          where c.idCasa == idCas
                          select q;
            quartos.AsEnumerable().Cast<Quarto>().ToList();
            return quartos;
        }
    }
}
