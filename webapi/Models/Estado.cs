﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

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
         * 3 - ativa
         * 4 - conluida
         */

        public virtual ICollection<Casa> Casas { get; set; }
        public virtual ICollection<Quarto> Quartos { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
