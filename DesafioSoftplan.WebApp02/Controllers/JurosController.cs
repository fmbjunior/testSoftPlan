using DesafioSoftplan.WebApp02.Config;
using DesafioSoftplan.WebApp02.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DesafioSoftplan.WebApp02.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JurosController : ControllerBase
    {
        [HttpGet("/calculajuros")]
        public object Get(decimal valorInicial, int meses)
        {
            try
            {
                if (valorInicial > 0 && meses > 0)
                {
                    string urlTaxa = JsonConfig.GetSectionConfig("API_Access:UrlTaxa");
                    double valorCalcular = Convert.ToDouble(valorInicial);
                    var retornoApiTaxa = HttpHelper.GetResult(urlTaxa);
                    double taxa = 0f;

                    if (retornoApiTaxa == null)
                    {
                        throw new Exception("Erro na consulta da Taxa de Juros.");
                    }
                    else
                    {
                        taxa = (Convert.ToDouble(retornoApiTaxa) / 100f);
                    }

                    var valorRetorno = Math.Round((valorCalcular * Math.Pow((1 + taxa), meses)), 2, MidpointRounding.ToNegativeInfinity);

                    return Ok(string.Format("{0:0.00}", valorRetorno));
                }
                else
                {
                    return BadRequest("Parâmentros inválidos.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/showmethecode")]
        public object Show()
        {
            try
            {
                return Ok(JsonConfig.GetSectionConfig("Url_Git"));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}