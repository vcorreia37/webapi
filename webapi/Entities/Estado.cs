using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace webapi.Entities
{
    public class Estado
    {
        [Key]
        public int idEstado { get; set; }
        public string estado { get; set; }
    }
}
