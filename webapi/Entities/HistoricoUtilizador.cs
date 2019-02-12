using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace webapi.Entities
{
    public class HistoricoUtilizador
    {
        [Key]
        public int idHistorico { get; set; }
        public int idUtilizador { get; set; }
        public string acao { get; set; }
        public DateTime  dataAcao { get; set; }

        public virtual Utilizador Utilizador { get; set; }
    }
}
