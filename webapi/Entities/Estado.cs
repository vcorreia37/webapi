using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace webapi.Entities
{
    public class Estado
    {
        [Key]
        public int idEstado { get; set; }
        [MaxLength(50)]
        public string estado { get; set; }

        public virtual ICollection<Casa> Casas { get; set; }
        public virtual ICollection<Quarto> Quartos { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
