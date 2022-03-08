#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutomobileAPI.Repository;
using AutomobileAPI.Repository.Models;
using AutomobileAPI.ViewModels;
using AutomobileAPI.BusinessLayer;
using System.Text.Json;
using Microsoft.Data.SqlClient;

namespace AutomobileAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarForSalesController : ControllerBase
    {
        private readonly AutomobileDbContext _context;
        private IProcessCarForSale _processCarForSale;

        public CarForSalesController(AutomobileDbContext context, IProcessCarForSale processCarForSale)
        {
            _context = context;
            _processCarForSale = processCarForSale;
        }

        // GET: api/CarForSales
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CarForSale>>> GetCarForSales()
        //{
        //    return await _context.CarForSales.ToListAsync();
        //}

        // GET: api/CarForSales/5
        [HttpGet("{id},{zipcode}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CarForSaleView>))]
        [ProducesResponseType(406)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<CarForSaleView>> GetCarForSale(int id,string zipcode)
        {
            ObjectResult result;
            try
            {
                var carForSale = _processCarForSale.GetCarForSale(id, zipcode);

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

        // PUT: api/CarForSales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCarForSale(int id, CarForSale carForSale)
        //{
        //    if (id != carForSale.CarForSaleId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(carForSale).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CarForSaleExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/CarForSales
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<CarForSale>> PostCarForSale(CarForSale carForSale)
        //{
        //    _context.CarForSales.Add(carForSale);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCarForSale", new { id = carForSale.CarForSaleId }, carForSale);
        //}

        //// DELETE: api/CarForSales/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCarForSale(int id)
        //{
        //    var carForSale = await _context.CarForSales.FindAsync(id);
        //    if (carForSale == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.CarForSales.Remove(carForSale);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool CarForSaleExists(int id)
        //{
        //    return _context.CarForSales.Any(e => e.CarForSaleId == id);
        //}
    }
}
