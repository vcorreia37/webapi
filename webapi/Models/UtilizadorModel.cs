using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi.Entities;
using webapi.Context;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace webapi.Models
{
    public class UtilizadorModel : Model<Utilizador>
    {
        public UtilizadorModel(BdContext context) : base(context)
        {
        }

        /*public Boolean UpdateUtilizador(Utilizador utilizador, string password)
        {

        }*/
    }
}
