using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using webapi.Entities;
using webapi.Context;
using webapi.Models;
using webapi.DTO;
using System.IO;
using System.Text;

namespace webapi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]

    public class AuthenticationController : ControllerBase
    {
        private AuthenticationModel _authenticationModel;
        private readonly AppSettings _appSettings;
        private BdContext _context;

        public AuthenticationController(BdContext context, IOptions<AppSettings> appSettings)
        {
            this._context = context;
            this._authenticationModel = new AuthenticationModel(context);
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Autenticate([FromBody]UtilizadorDTO utilizadorDTO)
        {
            string User;
            string Nome;
            

            var utilizador = _authenticationModel.AuthenticateUtilizador(utilizadorDTO.username, utilizadorDTO.password);
            
            if(utilizador == null)
            {
                return JsonResp.Response(0, "Username ou password estão incorretos");
            }
            else
            {
                User = utilizador.username;
                Nome = utilizador.nome;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, User),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenUtilizador = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(tokenUtilizador);

            return JsonResp.Response(1, new
            {
                username = User,
                nome = Nome,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("registar/utilizador")]
        public IActionResult RegistarUtilizador([FromBody] JObject obj)
        {
            if(obj.GetValue("username") == null ||
                obj.GetValue("password") == null ||
                obj.GetValue("tipoUtilizador") == null ||
                obj.GetValue("email") == null)
            {
                return JsonResp.Response(0, "Os campos obrigatórios tem que ser preenchidos");
            }

            String password = obj.GetValue("password").ToString();
            Utilizador uti = new Utilizador();
            uti.username = obj.GetValue("username").ToString();
            uti.email = obj.GetValue("email").ToString();

            try
            {
                var registo = _authenticationModel.CreateUtilizador(uti, password);
                if (registo)
                    return JsonResp.Response(1, "Utilizador criado com sucesso!");
                else
                    return JsonResp.Response(0, "Não foi possivel criar um novo utilizador");
            }
        }
    }
}
