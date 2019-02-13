using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace webapi.Entities
{
    public class CasaUtilizador
    {
        [Key]
        public int idCasaUtilizador { get; set; }
        public int idCasa { get; set; }
        public int idUtilizador { get; set; }
        [MaxLength(500)]
        public string nota { get; set; }

        public virtual Utilizador Utilizador { get; set; }
        public virtual Casa Casa { get; set; }
    }
}
