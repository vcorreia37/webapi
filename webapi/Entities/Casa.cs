using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace webapi.Entities
{
    public class Casa
    {
        [Key]
        public int idCasa { get; set; }
        public int idMorada { get; set; }
        public string descricao { get; set; }
        public int idEstado { get; set; }

        public virtual ICollection<CasaUtilizador> CasaUtilizadors { get; set; }
        public virtual ICollection<Quarto> Quartos { get; set; }

        public virtual Estado Estado { get; set; }
        public virtual Morada Morada { get; set; }
    }
}
