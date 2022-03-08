using AutomobileAPI.BusinessLayer;
using AutomobileAPI.Repository;
using AutomobileAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Text.Json;

namespace AutomobileAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarForSalesMultiController : ControllerBase
    {
        private readonly AutomobileDbContext _context;
        private IProcessCarForSale _processCarForSale;
        public CarForSalesMultiController(AutomobileDbContext context, IProcessCarForSale processCarForSale)
        {
            _context = context;
            _processCarForSale = processCarForSale;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CarForSaleView>))]
        [ProducesResponseType(406)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<CarForSaleView>> GetCarForSaleMulti([FromQuery] string CarModelIds, string Zipcodes)
        {
            ObjectResult result;
            try
            {
                var Ids = CarModelIds.Split(new char[] { ',' });
                List<int> ids = new List<int>();
                foreach (var str in Ids)
                {
                    ids.Add(Convert.ToInt32(str));
                }
                var codes = Zipcodes.Split(new char[] { ',' });
                List<string> zipcodes = new List<string>();
                foreach (var code in codes)
                {
                    zipcodes.Add(code);
                }
                CarSaleMulti carSaleMulti = new CarSaleMulti{ CarModelIds=ids,Zipcodes=zipcodes};

                var carForSale = _processCarForSale.GetCarForSaleMulti(carSaleMulti);

                if (carForSale == null)
                {
                    return NotFound();
                }
                var options = new JsonSerializerOptions()
                {
                    MaxDepth = 0,
                    IgnoreReadOnlyProperties = true
                };
                result = StatusCode(200, JsonSerializer.Serialize(carForSale, options));
            }
            catch (ArgumentException exception)
            {
                result = StatusCode(406, exception.Message);
            }
            catch (SqlException exception)
            {
                result = StatusCode(406, exception.Message);
            }
            catch (Exception exception)
            {
                result = StatusCode(500, exception.Message);
            }
            return result;
        }
    }
}
