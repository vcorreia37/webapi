using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace webapi.Entities
{
    public class TipoNotificacaoTB
    {
        [Key]
        public int idTipoNotificacao { get; set; }
        [MaxLength(50)]
        public string tipoNotificacao { get; set; }

        public virtual ICollection<Notificacao> Notificacaos { get; set; }
    }
}
