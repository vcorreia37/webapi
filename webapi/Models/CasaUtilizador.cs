using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Models
{
    public class CasaUtilizador
    {
        [Key]
        public int idCasaUtilizador { get; set; }
        public int idCasa { get; set; }
        public int idUtilizador { get; set; }
        [StringLength(500)]
        public string nota { get; set; }

        public virtual Utilizador Utilizador { get; set; }
        public virtual Casa Casa { get; set; }
    }
}
