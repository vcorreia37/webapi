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


    public class TipoUtilizadorController : ControllerBase
    {
        private readonly BdContext _context;

        public TipoUtilizadorController(BdContext context)
        {
            _context = context;
        }

        //Read TipoUtilizador
        [HttpGet]
        public IEnumerable<TipoUtilizadorTB> GetTipoUtilizadoress()
        {
            return _context.TipoUtilizadorTBs;
        }

        //Read TipoUtilizador
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoUtilizadorTB>> GetTipoUtilizador(int idTipUti)
        {
            TipoUtilizadorTB tipoUtilizador = await _context.TipoUtilizadorTBs.FindAsync(idTipUti);

            if (tipoUtilizador == null)
            {
                return NotFound();
            }

            return tipoUtilizador;
        }

        //Create TipoUtilizador
        [HttpPost]
        public async Task<ActionResult<TipoUtilizadorTB>> CreateTipoUtilizador(TipoUtilizadorTB tipoUtilizador)
        {
            _context.TipoUtilizadorTBs.Add(tipoUtilizador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoUtilizador", new { idNotificacao = tipoUtilizador.idTipo }, tipoUtilizador);
        }

        private Boolean FindTipoUtilizador(int idTipUti)
        {
            return _context.TipoUtilizadorTBs.Any(u => u.idTipo == idTipUti;

        //Update TipoUtilizador
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTipoUtilizador(int idTipUti, TipoUtilizadorTB tipoUtilizador)
        {
            if (idTipUti != tipoUtilizador.idTipo)
            {
                return NotFound();
            }

            _context.Entry(tipoUtilizador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                if (!FindTipoUtilizador(idTipUti))
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

        //Delete TipoUtilizador
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoUtilizadorTB>> DeleteTipoUtilizador(int idTipUti)
        {
            var tipoUtilizador = await _context.TipoUtilizadorTBs.FindAsync(idTipUti);
            if (tipoUtilizador == null)
            {
                return NotFound();
            }

            _context.TipoUtilizadorTBs.Remove(tipoUtilizador);
            await _context.SaveChangesAsync();

            return tipoUtilizador;
        }
    }
}
