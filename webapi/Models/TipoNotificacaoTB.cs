using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Models
{
    public class TipoNotificacaoTB
    {
        [Key]
        public int idTipoNotificacao { get; set; }
        [StringLength(50)]
        public string tipoNotificacao { get; set; }

        public virtual ICollection<Notificacao> Notificacaos { get; set; }
    }
}
