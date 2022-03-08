using AutomobileAPI.Repository;
using AutomobileAPI.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AutomobileAPI.DataLayer
{
    public class CarModelDAL : ICarModelDAL
    {
        private readonly AutomobileDbContext _context;

        public CarModelDAL(AutomobileDbContext context)
        {
            _context=context;
        }
        public async Task<IEnumerable<CarModelView>> GetCarModel(int carMakeId)
        {
            return await _context.CarModels.Where(x=>x.CarMakeId==carMakeId).Select(y=>new CarModelView { CarModelId=y.CarModelId,CarModelName=y.CarModelName}).ToListAsync();
        }

        public async Task<IEnumerable<CarModelView>> GetCarModelMulti(string carMakeIds)
        {
            var item = _context.CarModelsMultis.FromSqlRaw($"exec sp_GetCarModels '{carMakeIds}'").ToList();

            return item.Select(x => new CarModelView { CarModelId=x.CarModelId,CarModelName=x.CarModelName}).ToList();
        }
    }
}
