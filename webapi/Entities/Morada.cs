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
        [MaxLength(150)]
        public string morada { get; set; }
        [MaxLength(50)]
        public string localidade { get; set; }
        [MaxLength(8)]
        public string copPostal { get; set; }
        [MaxLength(50)]
        public string pais { get; set; }
        [MaxLength(50)]
        public string cidade { get; set; }

        public virtual ICollection<Utilizador> Utilizadors { get; set; }
        public virtual ICollection<Casa> Casas { get; set; }
    }
}
