using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Models
{
    public class Estado
    {
        [Key]
        public int idEstado { get; set; }
        [StringLength(50)]
        public string estado { get; set; }
        /*
         * 0 - livre
         * 1 - ocupado
         * 2 - reservado
         */

        public virtual ICollection<Casa> Casas { get; set; }
        public virtual ICollection<Quarto> Quartos { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
