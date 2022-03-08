using AutomobileAPI.ViewModels;

namespace AutomobileAPI.DataLayer
{
    public interface ICarForSaleDAL
    {
        Task<IEnumerable<CarForSaleView>> GetCarForSale(int carModelId, string zipcode);
        Task<IEnumerable<CarForSaleView>> GetCarForSaleMulti(CarSaleMulti carSaleMulti);
    }
}
