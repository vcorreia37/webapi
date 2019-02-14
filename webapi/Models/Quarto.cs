using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class Quarto
    {
        [Key]
        public int idQuarto { get; set; }
        public int idCasa { get; set; }
        [StringLength(20)]
        public string preco { get; set; }
        [StringLength(500)]
        public string descricao { get; set; }
        public int idEstado { get; set; }
        public int hospedes { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; }
        public virtual ICollection<Imagem> Imagems { get; set; }

        public virtual Casa Casa { get; set; }
        public virtual Estado Estado { get; set; }
    }
}
