using AutomobileAPI.ViewModels;

namespace AutomobileAPI.DataLayer
{
    public interface ICarModelDAL
    {
        Task<IEnumerable<CarModelView>> GetCarModel(int carMakeId);
        Task<IEnumerable<CarModelView>> GetCarModelMulti(string carMakeIds);
    }
}
