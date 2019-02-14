using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Context;
using Microsoft.Extensions.Options;
using webapi.DTO;
using webapi.Entities;

namespace webapi.Controllers 
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UtilizadorController : ControllerBase
    {
        private UtilizadorModel _utilizadorModel;
        private readonly AppSettings _appSettings;
        private BdContext _context;

        public UtilizadorController(BdContext context, IOptions<AppSettings> appSettings)
        {
            this._context = context;
            this._utilizadorModel = new UtilizadorModel(context);
            _appSettings = appSettings.Value;
        }

        [Authorize(Roles = "Utilizador")]
        [HttpPost("update")]
        public IActionResult UpdateUtilizador(UpdateUtilizadorDTO obj)
        {
            Utilizador utilizador = new Utilizador();
            utilizador.username = obj.username;
            utilizador.password = obj.password;
            utilizador.nome = obj.nome;
            utilizador.contacto = obj.contacto;
            utilizador.email = obj.email;

           
        }
    }
}
