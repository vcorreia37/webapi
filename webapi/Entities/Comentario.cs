using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace webapi.Entities
{
    public class Comentario
    {
        [Key]
        public int idComentario{ get; set; }
        [StringLength(500)]
        public string comentario { get; set; }
        public int idReserva { get; set; }

        public virtual Reserva Reserva { get; set; }
    }
}
