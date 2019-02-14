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

    public class MoradaController : ControllerBase
    {
        private readonly BdContext _context;

        public MoradaController(BdContext context)
        {
            _context = context;
        }

        //Read Moradas
        [HttpGet]
        public IEnumerable<Morada> GetMoradas()
        {
            return _context.Moradas;
        }

        //Read Morada
        [HttpGet("{id}")]
        public async Task<ActionResult<Morada>> GetMorada(int idMor)
        {
            Morada morada = await _context.Moradas.FindAsync(idMor);

            if (morada == null)
            {
                return NotFound();
            }

            return morada;
        }

        //Create Morada
        [HttpPost]
        public async Task<ActionResult<Morada>> CreateMorada(Morada morada)
        {
            _context.Moradas.Add(morada);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMorada", new { idMorada = morada.idMorada }, morada);
        }

        private Boolean FindMorada(int idMor)
        {
            return _context.Moradas.Any(m => m.idMorada == idMor;
        }

        //Update Morada
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMorada(int idMor, Morada morada)
        {
            if (idMor != morada.idMorada
            {
                return NotFound();
            }

            _context.Entry(morada).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                if (!FindMorada(idMor))
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

        //Delete Morada
        [HttpDelete("{id}")]
        public async Task<ActionResult<Morada>> DeleteMorada(int idMor)
        {
            var morada = await _context.Moradas.FindAsync(idMor);
            if (morada == null)
            {
                return NotFound();
            }

            _context.Moradas.Remove(morada);
            await _context.SaveChangesAsync();

            return morada;
        }

    }
}
