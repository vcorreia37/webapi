using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Models
{
    public class Reserva
    {
        [Key]
        public int idReserva { get; set; }
        public DateTime dataReserva { get; set; }
        public DateTime dataSaida { get; set; }
        public int idEstado { get; set; }
        public int idUtilizador { get; set; }
        public int idQuarto { get; set; }

        public virtual ICollection<Comentario> Comentarios { get; set; }

        public virtual Estado Estado { get; set; }
        public virtual Quarto Quarto { get; set; }
        public virtual Utilizador Utilizador { get; set; }
    }
}
