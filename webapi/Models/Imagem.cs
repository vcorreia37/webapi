using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Models
{
    public class Imagem
    {
        [Key]
        public int idImagem { get; set; }
        public string imagem { get; set; }
        [StringLength(500)]
        public string nomeImagem { get; set; }
        [StringLength(500)]
        public string contentTypeImagem { get; set; }
        public int idQuarto { get; set; }

        public virtual Quarto Quarto { get; set; }
    }
}
