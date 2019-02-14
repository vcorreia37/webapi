using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Entities;
using webapi.Context;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace webapi.Models
{
    public class AuthenticationModel
    {
        private BdContext _context;

        public AuthenticationModel(BdContext context)
        {
            _context = context;
        }

        public Utilizador AuthenticateUtilizador(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;


            var user = _context.Utilizadors.SingleOrDefault(u => u.username == username && u.password == password);
            if (user == null)
                return null;

            if (password != user.password)
                return null;

            return user;
        }

        public Boolean CreateUtilizador(Utilizador utilizador, string password)
        {
            if(string.IsNullOrEmpty(utilizador.username) || string.IsNullOrEmpty(utilizador.password) 
                || string.IsNullOrEmpty(utilizador.email))
            {
                throw new ApplicationException("tem que preencher os campos obrigatorios");
            }

            Regex regEmail = new Regex(@"^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]+$");
            if(!(regEmail.Match(utilizador.email)).Success)
            {
                throw new ApplicationException("Não é um email válido");
            }

            if (_context.Utilizadors.Any(u => u.username == utilizador.username))
                throw new ApplicationException("O username" + utilizador.username + "já existe!");

            if(_context.Utilizadors.Any(e => e.email == utilizador.email))
                throw new ApplicationException("O email" + utilizador.email + "já existe!");

            if (string.IsNullOrWhiteSpace(password))
                throw new ApplicationException("A password não pode conter espaços em branco!");

            using (var dbTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    this._context.Utilizadors.Add(utilizador);
                    this._context.SaveChanges();
                }
                catch(Exception)
                {
                    dbTransaction.Rollback();
                    return false;
                }
            }

                return true;
        }
    }
}
