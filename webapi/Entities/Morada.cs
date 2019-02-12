using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace webapi.Entities
{
    public class Morada
    {
        [Key]
        public int idMorada { get; set; }
        public string morada { get; set; }
        public string localidade { get; set; }
        public string copPostal { get; set; }
        public string pais { get; set; }
        public string cidade { get; set; }
    }
}
