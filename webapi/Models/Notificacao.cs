using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class Notificacao
    {
        [Key]
        public int idNotificacao { get; set; }
        public int idTipoNotificacao { get; set; }
        public DateTime dataEfetuada { get; set; }
        public int idUtilizador { get; set; }

        public virtual Utilizador Utilizador { get; set; }
        public virtual TipoNotificacaoTB TipoNotificacaoTB { get; set; }
    }
}
