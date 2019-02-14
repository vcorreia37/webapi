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

    public class EstadoController : ControllerBase
    {
        private readonly BdContext _context;

        public EstadoController(BdContext context)
        {
            _context = context;
        }

        //Read Estados
        [HttpGet]
        public IEnumerable<Estado> GetEstados()
        {
            return _context.Estados;
        }

        //Read Estado
        [HttpGet("{id}")]
        public async Task<ActionResult<Estado>> GetEstado(int idEst)
        {
            Estado estado = await _context.Estados.FindAsync(idEst);

            if (estado == null)
            {
                return NotFound();
            }

            return estado;
        }

        //Create Estado
        [HttpPost]
        public async Task<ActionResult<Estado>> CreateEstado(Estado estado)
        {
            _context.Estados.Add(estado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstado", new { idEstado = estado.idEstado }, estado);
        }

        private Boolean FindEstado(int idEst)
        {
            return _context.Estados.Any(e => e.idEstado == idEst);
        }

        //Update Estado
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEstado(int idEst, Estado estado)
        {
            if (idEst != estado.idEstado)
            {
                return NotFound();
            }

            _context.Entry(estado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                if (!FindEstado(idEst))
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

        //Delete Estado
        [HttpDelete("{id}")]
        public async Task<ActionResult<Estado>> DeleteEstado(int idEst)
        {
            var estado = await _context.Estados.FindAsync(idEst);
            if (estado == null)
            {
                return NotFound();
            }

            _context.Estados.Remove(estado);
            await _context.SaveChangesAsync();

            return estado;
        }
    }
}
