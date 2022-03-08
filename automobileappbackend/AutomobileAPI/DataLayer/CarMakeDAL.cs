using AutomobileAPI.Repository;
using AutomobileAPI.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AutomobileAPI.DataLayer
{
    public class CarMakeDAL : ICarMakeDAL
    {
        private readonly AutomobileDbContext _context;

        public CarMakeDAL(AutomobileDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CarMakeView>> GetCarMakes()
        {
            return await _context.CarMakes.Select(x => new CarMakeView { CarMakeId = x.CarMakeId, CarMakeName = x.CarMakeName }).ToListAsync();
        }
        public async Task<CarMakeView> GetCarMakes(int id)
        {
            return await _context.CarMakes.Where(x=>x.CarMakeId==id).Select(x => new CarMakeView { CarMakeId = x.CarMakeId, CarMakeName = x.CarMakeName }).SingleOrDefaultAsync();
        }
    }
}
