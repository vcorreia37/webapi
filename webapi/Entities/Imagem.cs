using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace webapi.Entities
{
    public class Imagem
    {
        [Key]
        public int idImagem { get; set; }
        public string imagem { get; set; }
        [MaxLength(500)]
        public string nomeImagem { get; set; }
        [MaxLength(500)]
        public string contentTypeImagem { get; set; }
        public int idQuarto { get; set; }

        public virtual Quarto Quarto { get; set; }
    }
}
