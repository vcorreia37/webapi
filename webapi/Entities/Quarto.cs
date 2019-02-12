using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace webapi.Entities
{
    public class Quarto
    {
        [Key]
        public int idQuarto { get; set; }
        public int idCasa { get; set; }
        public string preco { get; set; }
        public string descricao { get; set; }
        public int idEstado { get; set; }
    }
}
