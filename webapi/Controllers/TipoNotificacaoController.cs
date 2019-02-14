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

    public class TipoNotificacaoController : ControllerBase
    {
        private readonly BdContext _context;

        public TipoNotificacaoController(BdContext context)
        {
            _context = context;
        }

        //Read TipoNotificacaoes
        [HttpGet]
        public IEnumerable<TipoNotificacaoTB> GetTipoNotificacoes()
        {
            return _context.TipoNotificacaoTBs;
        }

        //Read TipoNotificacao
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoNotificacaoTB>> GetTipoNotificacao(int idTipNot)
        {
            TipoNotificacaoTB tipoNotificacao = await _context.TipoNotificacaoTBs.FindAsync(idTipNot);

            if (tipoNotificacao == null)
            {
                return NotFound();
            }

            return tipoNotificacao;
        }

        //Create TipoNotificacao
        [HttpPost]
        public async Task<ActionResult<TipoNotificacaoTB>> CreateTipoNotificacao(TipoNotificacaoTB tipoNotificacao)
        {
            _context.TipoNotificacaoTBs.Add(tipoNotificacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoNotificacao", new { idNotificacao = tipoNotificacao.idTipoNotificacao }, tipoNotificacao);
        }

        private Boolean FindTipoNotificacao(int idTipNot)
        {
            return _context.TipoNotificacaoTBs.Any(n => n.idTipoNotificacao == idTipNot);
        }

        //Update TipoNotificacao
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTipoNotificacao(int idTipNot, TipoNotificacaoTB tipoNotificacao)
        {
            if (idTipNot != tipoNotificacao.idTipoNotificacao)
            {
                return NotFound();
            }

            _context.Entry(tipoNotificacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                if (!FindTipoNotificacao(idTipNot))
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

        //Delete TipoNotificacao
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoNotificacaoTB>> DeleteTipoNotificacao(int idTipNot)
        {
            var tipoNotificacao = await _context.TipoNotificacaoTBs.FindAsync(idTipNot);
            if (tipoNotificacao == null)
            {
                return NotFound();
            }

            _context.TipoNotificacaoTBs.Remove(tipoNotificacao);
            await _context.SaveChangesAsync();

            return tipoNotificacao;
        }
    }
}
