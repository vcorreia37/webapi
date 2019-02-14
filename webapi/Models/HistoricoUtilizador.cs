using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class HistoricoUtilizador
    {
        [Key]
        public int idHistorico { get; set; }
        public int idUtilizador { get; set; }
        [StringLength(500)]
        public string acao { get; set; }
        public DateTime dataAcao { get; set; }

        public virtual Utilizador Utilizador { get; set; }
    }
}
