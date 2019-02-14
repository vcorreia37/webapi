using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Context;
using webapi.Models;
using Microsoft.EntityFrameworkCore;



namespace webapi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UtilizadorController : ControllerBase
    {
        private readonly BdContext _context;

        public UtilizadorController(BdContext context)
        {
            _context = context;
        }

        //Read Utilizadores
        [HttpGet]
        public IEnumerable<Utilizador> GetUtilizadores()
        {
            return _context.Utilizadors;
        }

        //Read Utilizador
        [HttpGet("{id}")]
        public async Task<ActionResult<Utilizador>> GetUtilizador(int idUti)
        {
            Utilizador utilizador = await _context.Utilizadors.FindAsync(idUti);

            if(utilizador == null)
            {
                return NotFound();
            }

            return utilizador;
        }

        //Create Utilizador
        [HttpPost]
        public async Task<ActionResult<Utilizador>> CreateUtilizador(Utilizador utilizador)
        {
            _context.Utilizadors.Add(utilizador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUtilizador", new { idUtilizador = utilizador.idUtilizador }, utilizador);
        }

        private Boolean FindUtilizador(int idUti)
        {
            return _context.Utilizadors.Any(u => u.idUtilizador == idUti);
        }

        //Update Utilizador
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUtilizador(int idUti, Utilizador utilizador)
        {
            if(idUti != utilizador.idUtilizador)
            {
                return NotFound();
            }

            _context.Entry(utilizador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                if(!FindUtilizador(idUti))
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

        //Delete Utilizador
        [HttpDelete("{id}")]
        public async Task<ActionResult<Utilizador>> DeleteUtilizador(int idUti)
        {
            var utilizador = await _context.Utilizadors.FindAsync(idUti);
            if(utilizador ==  null)
            {
                return NotFound();
            }

            _context.Utilizadors.Remove(utilizador);
            await _context.SaveChangesAsync();

            return utilizador;
        }

        [HttpGet("{id}/senhorio")]
        public IEnumerable<Utilizador> GetSenhorios()
        {
            var utilizador = from u in _context.Utilizadors
                         where u.idTipUtilizador == 2
                         select u;
            utilizador.AsEnumerable().Cast<Utilizador>().ToList();
            return utilizador;
        }

        [HttpGet("{id}/estudantes")]
        public IEnumerable<Utilizador> GetEstudantes()
        {
            var utilizador = from u in _context.Utilizadors
                             where u.idTipUtilizador == 3
                             select u;
            utilizador.AsEnumerable().Cast<Utilizador>().ToList();
            return utilizador;
        }
    }
}
