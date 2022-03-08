using AutomobileAPI.Repository;
using AutomobileAPI.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AutomobileAPI.DataLayer
{
    public class CarForSaleDAL : ICarForSaleDAL
    {
        private readonly AutomobileDbContext _context;

        public CarForSaleDAL(AutomobileDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<IEnumerable<CarForSaleView>> GetCarForSale(int carModelId, string zipcode)
        {
            return await _context.VwCarsForSales
                .Where(x => x.CarModelId==carModelId && x.ZipCode==zipcode)
                .Select(y => new CarForSaleView {
                    CarForSaleId=y.CarForSaleId,
                    CarModelId=y.CarModelId,
                    CarMakeName=y.CarMakeName,
                    CarModelName=y.CarModelName,
                    Miles=y.Miles,
                    Ratings=y.Ratings,
                    ZipCode=y.ZipCode,
                    SellerName=y.SellerName,
                    SellerContactDetails=y.SellerContactDetails,
                    Price=y.Price,
                    Color=y.Color,
                    Image=y.Image })
                .ToListAsync();
        }
        public async Task<IEnumerable<CarForSaleView>> GetCarForSaleMulti(CarSaleMulti carSaleMulti)
        {
            var item = _context.VwCarsForSales.FromSqlRaw($"exec sp_GetCarsForSale '{string.Join(",", carSaleMulti.CarModelIds)}','{string.Join(",", carSaleMulti.Zipcodes)}'").ToList();
            return item.Select(y => new CarForSaleView
            {
                CarForSaleId = y.CarForSaleId,
                CarModelId = y.CarModelId,
                CarMakeName = y.CarMakeName,
                CarModelName = y.CarModelName,
                Miles = y.Miles,
                Ratings = y.Ratings,
                ZipCode = y.ZipCode,
                SellerName = y.SellerName,
                SellerContactDetails = y.SellerContactDetails,
                Price = y.Price,
                Color = y.Color,
                Image = y.Image
            }).ToList();
            //
        }
    }
}
