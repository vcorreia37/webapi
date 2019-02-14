using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace webapi.Entities
{
    public class TipoUtilizadorTB
    {
        [Key]
        public int idTipo { get; set; }
        [StringLength(20)]
        public string tipo { get; set; }

        public virtual ICollection<Utilizador> Utilizadors { get; set; }
    }
}
