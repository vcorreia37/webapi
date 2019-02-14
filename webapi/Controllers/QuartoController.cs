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

    public class QuartoController : ControllerBase
    {
        private readonly BdContext _context;

        public QuartoController(BdContext context)
        {
            _context = context;
        }

        //Read Quartos
        [HttpGet]
        public IEnumerable<Quarto> GetQuartos()
        {
            return _context.Quartos;
        }

        //Read Quarto
        [HttpGet("{id}")]
        public async Task<ActionResult<Quarto>> GetQuarto(int idQuar)
        {
            Quarto quarto = await _context.Quartos.FindAsync(idQuar);

            if (quarto == null)
            {
                return NotFound();
            }

            return quarto;
        }

        //Create Quarto
        [HttpPost]
        public async Task<ActionResult<Quarto>> CreateQuarto(Quarto quarto)
        {
            _context.Quartos.Add(quarto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuarto", new { idQuarto = quarto.idQuarto }, quarto);
        }

        private Boolean FindQuarto(int idQuar)
        {
            return _context.Quartos.Any(q => q.idQuarto == idQuar);
        }

        //Update Quarto
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuarto(int idQuar, Quarto quarto)
        {
            if (idQuar!= quarto.idQuarto)
            {
                return NotFound();
            }

            _context.Entry(quarto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                if (!FindQuarto(idQuar))
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

        //Delete Quarto
        [HttpDelete("{id}")]
        public async Task<ActionResult<Quarto>> DeleteQuarto(int idQuar)
        {
            var quarto = await _context.Quartos.FindAsync(idQuar);
            if (quarto == null)
            {
                return NotFound();
            }

            _context.Quartos.Remove(quarto);
            await _context.SaveChangesAsync();

            return quarto;
        }

        [HttpGet("{id}/imagens")]
        public IEnumerable<Imagem> GetImagensQuarto(int idQuar)
        {
            var imagens = from i in _context.Imagems
                          join q in _context.Quartos on i.idQuarto equals q.idQuarto
                          where q.idQuarto == idQuar
                          select i;
            imagens.AsEnumerable().Cast<Imagem>().ToList();
            return imagens;
        }

        [HttpGet("{id}/reservas")]
        public IEnumerable<Reserva> GetReservasQuarto(int idQuar)
        {
            var reservas = from r in _context.Reservas
                           join q in _context.Quartos on r.idQuarto equals q.idQuarto
                           where q.idQuarto == idQuar
                           select r;
            reservas.AsEnumerable().Cast<Reserva>().ToList();
            return reservas;
        }

        [HttpGet("{id}/livre")]
        public IEnumerable<Quarto> GetQuartosLivres()
        {
            var quarto = from q in _context.Quartos
                       where q.idEstado == 0
                       select q;
            quarto.AsEnumerable().Cast<Quarto>().ToList();
            return quarto;
        }

        [HttpGet("{id}/reservado")]
        public IEnumerable<Quarto> GetQuartosReservados()
        {
            var quarto = from q in _context.Quartos
                       where q.idEstado == 2
                       select q;
            quarto.AsEnumerable().Cast<Quarto>().ToList();
            return quarto;
        }

        [HttpGet("{id}/ocupado")]
        public IEnumerable<Quarto> GetQuartosOcupados()
        {
            var quarto = from q in _context.Quartos
                       where q.idEstado == 1
                       select q;
            quarto.AsEnumerable().Cast<Quarto>().ToList();
            return quarto;
        }
    }
}
