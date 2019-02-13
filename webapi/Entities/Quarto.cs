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
        [MaxLength(20)]
        public string preco { get; set; }
        [MaxLength(500)]
        public string descricao { get; set; }
        public int idEstado { get; set; }
        public int hospedes { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; } 
        public virtual ICollection<Imagem> Imagems { get; set; }

        public virtual Casa Casa { get; set; }
        public virtual Estado Estado { get; set; }
    }
}
