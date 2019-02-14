using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Models
{
    public class TipoUtilizadorTB
    {
        [Key]
        public int idTipo { get; set; }
        [StringLength(20)]
        public string tipo { get; set; }
        /*
         * 0 - admin
         * 1 - senhorio
         * 2- estudante
         */
        public virtual ICollection<Utilizador> Utilizadors { get; set; }
    }
}
