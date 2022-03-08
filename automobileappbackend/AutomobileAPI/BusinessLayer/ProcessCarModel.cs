using AutomobileAPI.DataLayer;
using AutomobileAPI.Repository;
using AutomobileAPI.ViewModels;

namespace AutomobileAPI.BusinessLayer
{
    public class ProcessCarModel : IProcessCarModel
    {
        private readonly ICarModelDAL _carModelDAL;
        private readonly AutomobileDbContext _context;
        public ProcessCarModel(ICarModelDAL carModelDAL,AutomobileDbContext dbContext)
        {
            _carModelDAL=carModelDAL;
            _context=dbContext;
        }
        public Task<IEnumerable<CarModelView>> GetCarModel(int id)
        {
            return _carModelDAL.GetCarModel(id);
        }

        public Task<IEnumerable<CarModelView>> GetCarModelMulti(string ids)
        {
            return _carModelDAL.GetCarModelMulti(ids);
        }
    }
}
