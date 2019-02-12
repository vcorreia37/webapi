using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace webapi.Entities
{
    public class Notificacao
    {
        [Key]
        public int idNotificacao { get; set; }
        public int idTipoNotificacao { get; set; }
        public DateTime dataEfetuada { get; set; }
        public int idUtilizador { get; set; }
    }
}
