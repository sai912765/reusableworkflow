using AutomobileAPI.ViewModels;

namespace AutomobileAPI.DataLayer
{
    public interface ICarMakeDAL
    {
        Task<IEnumerable<CarMakeView>> GetCarMakes();
        Task<CarMakeView> GetCarMakes(int id);
    }
}
