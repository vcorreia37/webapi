using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi.Entities;
using webapi.Context;
using System.Linq;
using System.Text.RegularExpressions;


namespace webapi.Models
{
    public class UtilizadorModel : Model<Utilizador>
    {
        public UtilizadorModel(BdContext context) : base(context)
        {
        }

        public Boolean UpdateUtilizador(Utilizador utilizador, int idUtilizador, string password)
        {
            Utilizador uti = this.GetById(idUtilizador);

            if (uti == null)
                throw new ApplicationException("Não foi possivel encontrar o utilizador");

            if (string.IsNullOrEmpty(utilizador.username) || string.IsNullOrEmpty(utilizador.password) ||
                string.IsNullOrEmpty(utilizador.email))
            {
                throw new ApplicationException("Preencha os campos obrigatorios");
            }

            Regex regexEmail = new Regex(@"^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[A-Za-z]+$");
            if (!(regexEmail.Match(utilizador.email)).Success)
            {
                throw new ApplicationException("Email invalio.");
            }

            if (_context.Utilizadors.Any(e => e.email == utilizador.email) && uti.email != utilizador.email)
                throw new ApplicationException("Este email " + utilizador.email + " já existe");

            uti.username = utilizador.username;
            uti.password = utilizador.password;
            uti.email = utilizador.email;

            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    this._context.Utilizadors.Update(uti);
                    this._context.SaveChanges();

                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }

                return true;
            }
        }
    }
}
