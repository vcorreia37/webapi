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

    public class NotificacaoController : ControllerBase
    {
        private readonly BdContext _context;

        public NotificacaoController(BdContext context)
        {
            _context = context;
        }

        //Read Notificacaoes
        [HttpGet]
        public IEnumerable<Notificacao> GetNotificacoes()
        {
            return _context.Notificacaos;
        }

        //Read Notificacao
        [HttpGet("{id}")]
        public async Task<ActionResult<Notificacao>> GetNotificacao(int idNot)
        {
            Notificacao notificacao = await _context.Notificacaos.FindAsync(idNot);

            if (notificacao == null)
            {
                return NotFound();
            }

            return notificacao;
        }

        //Create Notificacao
        [HttpPost]
        public async Task<ActionResult<Notificacao>> CreateNotificacao(Notificacao notificacao)
        {
            _context.Notificacaos.Add(notificacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotificacao", new { idNotificacao = notificacao.idNotificacao }, notificacao);
        }

        private Boolean FindNotificacao(int idNot)
        {
            return _context.Notificacaos.Any(n => n.idNotificacao == idNot;
        }

        //Update Notificacao
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotificacao(int idNot, Notificacao notificacao)
        {
            if (idNot != notificacao.idNotificacao)
            {
                return NotFound();
            }

            _context.Entry(notificacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                if (!FindNotificacao(idNot))
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

        //Delete Notificacao
        [HttpDelete("{id}")]
        public async Task<ActionResult<Notificacao>> DeleteNotificacao(int idNot)
        {
            var notificacao = await _context.Notificacaos.FindAsync(idNot);
            if (notificacao == null)
            {
                return NotFound();
            }

            _context.Notificacaos.Remove(notificacao);
            await _context.SaveChangesAsync();

            return notificacao;
        }
    }
}
