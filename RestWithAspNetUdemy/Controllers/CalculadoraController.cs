using Microsoft.AspNetCore.Mvc;

namespace RestWithAspNetUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculadoraController : ControllerBase
    {
      
        [HttpGet("Soma/{PrimeiroNumero}/{SegundoNumero}")]
        public IActionResult Soma(string primeiroNumero, string segundoNumero)
        {
            if (Isnumeric(primeiroNumero) && Isnumeric(segundoNumero))
            {
                var sum = ConverterParaDecimal(primeiroNumero) + ConverterParaDecimal(segundoNumero);
                return Ok(sum.ToString());
            
            }

            return BadRequest("Entrada inválida");
        }

        private decimal ConverterParaDecimal(string Numero)
        {
            decimal decimalValue;
            if(decimal.TryParse(Numero, out decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }

        private bool Isnumeric(string stringNumero)
        {
            double number;
            bool isNumber = double.TryParse(stringNumero, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;
        }
    }
}
