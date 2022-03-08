using AutomobileAPI.DataLayer;
using AutomobileAPI.Repository;
using AutomobileAPI.ViewModels;

namespace AutomobileAPI.BusinessLayer
{
    public class ProcessCarForSale: IProcessCarForSale
    {
        private readonly ICarForSaleDAL _carForSaleDAL;
        private readonly AutomobileDbContext _context;
        public ProcessCarForSale(AutomobileDbContext dbContext,ICarForSaleDAL carForSaleDAL)
        {
            _context = dbContext;
            _carForSaleDAL = carForSaleDAL;
        }

        public Task<IEnumerable<CarForSaleView>> GetCarForSale(int id, string zipcode)
        {
            return _carForSaleDAL.GetCarForSale(id, zipcode);
        }

        public Task<IEnumerable<CarForSaleView>> GetCarForSaleMulti(CarSaleMulti carSaleMulti)
        {
            return _carForSaleDAL.GetCarForSaleMulti(carSaleMulti);
        }
    }
}
