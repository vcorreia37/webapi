using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Models
{
    public class Casa
    {
        [Key]
        public int idCasa { get; set; }
        public int idMorada { get; set; }
        [StringLength(500)]
        public string descricao { get; set; }
        public int idEstado { get; set; }

        public virtual ICollection<CasaUtilizador> CasaUtilizadors { get; set; }
        public virtual ICollection<Quarto> Quartos { get; set; }

        public virtual Estado Estado { get; set; }
        public virtual Morada Morada { get; set; }
    }
}
