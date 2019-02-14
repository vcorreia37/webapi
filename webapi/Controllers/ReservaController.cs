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

    public class ReservaController : ControllerBase
    {
        private readonly BdContext _context;

        public ReservaController(BdContext context)
        {
            _context = context;
        }

        //Read Reservas
        [HttpGet]
        public IEnumerable<Reserva> GetReservas()
        {
            return _context.Reservas;
        }

        //Read Reserva
        [HttpGet("{id}")]
        public async Task<ActionResult<Reserva>> GetReserva(int idRes)
        {
            Reserva reserva = await _context.Reservas.FindAsync(idRes);

            if (reserva == null)
            {
                return NotFound();
            }

            return reserva;
        }

        //Create Reserva
        [HttpPost]
        public async Task<ActionResult<Reserva>> CreateReserva(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReserva", new { idReserva = reserva.idReserva }, reserva);
        }

        private Boolean FindReserva(int idRes)
        {
            return _context.Reservas.Any(r => r.idReserva == idRes);
        }

        //Update Reserva
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReserva(int idRes, Reserva reserva)
        {
            if (idRes != reserva.idReserva)
            {
                return NotFound();
            }

            _context.Entry(reserva).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                if (!FindReserva(idRes))
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

        //Delete Reserva
        [HttpDelete("{id}")]
        public async Task<ActionResult<Reserva>> DeleteReserva(int idRes)
        {
            var reserva = await _context.Reservas.FindAsync(idRes);
            if (reserva == null)
            {
                return NotFound();
            }

            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();

            return reserva;
        }

        [HttpGet("{id}/ativa")]
        public IEnumerable<Reserva> GetReservasAtivas()
        {
            var reserva = from r in _context.Reservas
                         where r.idEstado == 3
                         select r;
            reserva.AsEnumerable().Cast<Reserva>().ToList();
            return reserva;
        }

        [HttpGet("{id}/concluida")]
        public IEnumerable<Reserva> GetReservasConcluidas()
        {
            var reserva = from r in _context.Reservas
                          where r.idEstado == 4
                          select r;
            reserva.AsEnumerable().Cast<Reserva>().ToList();
            return reserva;
        }

        [HttpGet("{id}/concluida")]
        public IEnumerable<Comentario> GetComentarios(int idRes)
        {
            var comentarios = from c in _context.Comentarios
                          join r in _context.Reservas on c.idReserva equals r.idReserva
                          where r.idReserva == idRes
                          select c;
            comentarios.AsEnumerable().Cast<Comentario>().ToList();
            return comentarios;
        }

    }
}
