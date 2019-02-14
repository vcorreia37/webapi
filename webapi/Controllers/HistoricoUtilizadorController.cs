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

    public class HistoricoUtilizadorController : ControllerBase
    {
        private readonly BdContext _context;

        public HistoricoUtilizadorController(BdContext context)
        {
            _context = context;
        }

        //Read Historicos
        [HttpGet]
        public IEnumerable<HistoricoUtilizador> GetHistoricos()
        {
            return _context.HistoricoUtilizadors;
        }

        //Read Historico
        [HttpGet("{id}")]
        public async Task<ActionResult<HistoricoUtilizador>> GetHistorico(int idHist)
        {
            HistoricoUtilizador historico = await _context.HistoricoUtilizadors.FindAsync(idHist);

            if (historico == null)
            {
                return NotFound();
            }

            return historico;
        }

        //Create Historico
        [HttpPost]
        public async Task<ActionResult<HistoricoUtilizador>> CreateHistorico(HistoricoUtilizador historico)
        {
            _context.HistoricoUtilizadors.Add(historico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistorico", new { idHistorico = historico.idHistorico }, historico);
        }

        private Boolean FindHistorico(int idHist)
        {
            return _context.HistoricoUtilizadors.Any(h => h.idHistorico == idHist);
        }

        //Update Historico
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHistorico(int idHist, HistoricoUtilizador historico)
        {
            if (idHist != historico.idHistorico)
            {
                return NotFound();
            }

            _context.Entry(historico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                if (!FindHistorico(idHist))
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

        //Delete Historico
        [HttpDelete("{id}")]
        public async Task<ActionResult<HistoricoUtilizador>> DeleteHistorico(int idHist)
        {
            var historico = await _context.HistoricoUtilizadors.FindAsync(idHist);
            if (historico == null)
            {
                return NotFound();
            }

            _context.HistoricoUtilizadors.Remove(historico);
            await _context.SaveChangesAsync();

            return historico;
        }

    }
}
