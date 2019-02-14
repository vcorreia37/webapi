using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.DTO
{
    public class UpdateUtilizadorDTO
    {
        public string username { get; set; }
        public string password { get; set; }
        public string nome { get; set; }
        public int contacto { get; set; }
        public string email { get; set; }
    }
}
