using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Context;
using webapi.Models;


namespace webapi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UtilizadorController : ControllerBase
    {
        private readonly BdContext _context;

        public UtilizadorController(BdContext context)
        {
            _context = context;
        }

        //Create Utilizador
        [HttpPost]
        
    }
}
