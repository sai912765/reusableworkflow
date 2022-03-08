using AutomobileAPI.ViewModels;

namespace AutomobileAPI.BusinessLayer
{
    public interface IProcessCarForSale
    {
        Task<IEnumerable<CarForSaleView>> GetCarForSale(int id, string zipcode);
        Task<IEnumerable<CarForSaleView>> GetCarForSaleMulti(CarSaleMulti carSaleMulti);
    }
}
