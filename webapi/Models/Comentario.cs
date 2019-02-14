using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Models
{
    public class Comentario
    {
        [Key]
        public int idComentario { get; set; }
        [StringLength(500)]
        public string comentario { get; set; }
        public int idReserva { get; set; }

        public virtual Reserva Reserva { get; set; }
    }
}
