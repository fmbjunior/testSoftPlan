using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioSoftplan.WebApp01.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaxaController : ControllerBase
    {
        [HttpGet("/taxaJuros")]
        public object GetTaxaJuros()
        {
            return Ok(0.01);
        }
    }
}