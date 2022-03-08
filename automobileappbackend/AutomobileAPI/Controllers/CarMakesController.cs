#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutomobileAPI.Repository;
using AutomobileAPI.Repository.Models;
using AutomobileAPI.BusinessLayer;
using AutomobileAPI.ViewModels;
using AutomobileAPI.Business;
using Microsoft.Data.SqlClient;

namespace AutomobileAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarMakesController : ControllerBase
    {
        private readonly AutomobileDbContext _context;
        private IProcessCarMake _processCarMake;
        public CarMakesController(AutomobileDbContext context, IProcessCarMake processCarMake)
        {
            _context = context;
            _processCarMake = processCarMake;
        }

        //GET: api/CarMakes
       [HttpGet]
       [ProducesResponseType(200,Type=typeof(IEnumerable<CarMakeView>))]
       [ProducesResponseType(406)]
       [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<CarMakeView>>> GetCarMakes()
        {
            ObjectResult result;
            try
            {
                IEnumerable<CarMakeView> make = await _processCarMake.GetCarMakes();
                result = StatusCode(200, make);
            }
            catch(ArgumentException exception)
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

        // GET: api/CarMakes/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<CarMake>> GetCarMake(int id)
        //{
        //    var carMake = await _processCarMake.GetCarMakes(id);

        //    if (carMake == null)
        //    {
        //        return NotFound();
        //    }

        //    return StatusCode(200, carMake);
        //}

        //// PUT: api/CarMakes/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCarMake(int id, CarMake carMake)
        //{
        //    if (id != carMake.CarMakeId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(carMake).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CarMakeExists(id))
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

        //// POST: api/CarMakes
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<CarMake>> PostCarMake(CarMake carMake)
        //{
        //    _context.CarMakes.Add(carMake);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCarMake", new { id = carMake.CarMakeId }, carMake);
        //}

        //// DELETE: api/CarMakes/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCarMake(int id)
        //{
        //    var carMake = await _context.CarMakes.FindAsync(id);
        //    if (carMake == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.CarMakes.Remove(carMake);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool CarMakeExists(int id)
        //{
        //    return _context.CarMakes.Any(e => e.CarMakeId == id);
        //}
    }
}
