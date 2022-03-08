using AutomobileAPI.BusinessLayer;
using AutomobileAPI.Repository;
using AutomobileAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AutomobileAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarModelsMultiController : ControllerBase
    {
        private readonly AutomobileDbContext _context;
        private readonly IProcessCarModel _processCarModel;
        public CarModelsMultiController(AutomobileDbContext context, IProcessCarModel processCarModel)
        {
            _context=context;
            _processCarModel=processCarModel;
        }
        [HttpGet("{ids}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CarModelView>))]
        [ProducesResponseType(406)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<CarModelView>>> GetCarModelsMulti(string ids)
        {
            ObjectResult result;
            try
            {
                var carModel = await _processCarModel.GetCarModelMulti(ids); //await _context.CarModels.FindAsync(id);

                if (carModel == null)
                {
                    return NotFound();
                }

                result = StatusCode(200, carModel);
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
