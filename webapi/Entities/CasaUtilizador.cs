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
        public string nota { get; set; }
    }
}
