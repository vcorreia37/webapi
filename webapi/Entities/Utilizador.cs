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
        [Required]
        [StringLength(50)]
        public string username { get; set; }
        [Required]
        [StringLength(50)]
        public string password { get; set; }
        [StringLength(200)]
        public string nome { get; set; }
        public int idMorada { get; set; }
        public int contacto { get; set; }
        public int idTipUtilizador { get; set; }
        [Required]
        [StringLength(100)]
        public string email { get; set; }

        public virtual ICollection<Notificacao> Notificacaos { get; set; }
        public virtual ICollection<HistoricoUtilizador> HistoricoUtilizadors { get; set; }
        public virtual ICollection<CasaUtilizador> CasaUtilizadors { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }

        public virtual TipoUtilizadorTB TipoUtilizadorTB { get; set; }
        public virtual Morada Morada { get; set; }
    }
}
