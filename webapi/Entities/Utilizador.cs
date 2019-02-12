using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace webapi.Entities
{
    public class Utilizador
    {
        [Key]
        public int idUtilizador { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string nome { get; set; }
        public int idMorada { get; set; }
        public string contacto { get; set; }
        public int idTipUtilizador { get; set; }
        public string email { get; set; }

        public virtual ICollection<Notificacao> Notificacaos { get; set; }
        public virtual ICollection<HistoricoUtilizador> HistoricoUtilizadors { get; set; }
        public virtual ICollection<CasaUtilizador> CasaUtilizadors { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }

        public virtual TipoUtilizadorTB TipoUtilizadorTB { get; set; }
        public virtual Morada Morada { get; set; }
    }
}
