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
using Microsoft.Data.SqlClient;

namespace AutomobileAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarModelsController : ControllerBase
    {
        private readonly AutomobileDbContext _context;
        private IProcessCarModel _processCarModel;

        public CarModelsController(AutomobileDbContext context, IProcessCarModel processCarModel)
        {
            _context = context;
            _processCarModel = processCarModel;
        }

        // GET: api/CarModels
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CarModel>>> GetCarModels()
        //{
        //    return await _context.CarModels.ToListAsync();
        //}

        // GET: api/CarModels/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CarModelView>))]
        [ProducesResponseType(406)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<CarModelView>>> GetCarModel(string ids)
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

        // PUT: api/CarModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCarModel(int id, CarModel carModel)
        //{
        //    if (id != carModel.CarModelId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(carModel).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CarModelExists(id))
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

        //// POST: api/CarModels
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<CarModel>> PostCarModel(CarModel carModel)
        //{
        //    _context.CarModels.Add(carModel);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCarModel", new { id = carModel.CarModelId }, carModel);
        //}

        //// DELETE: api/CarModels/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCarModel(int id)
        //{
        //    var carModel = await _context.CarModels.FindAsync(id);
        //    if (carModel == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.CarModels.Remove(carModel);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool CarModelExists(int id)
        //{
        //    return _context.CarModels.Any(e => e.CarModelId == id);
        //}
    }
}
