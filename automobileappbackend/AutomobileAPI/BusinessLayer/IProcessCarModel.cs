using AutomobileAPI.ViewModels;

namespace AutomobileAPI.BusinessLayer
{
    public interface IProcessCarModel
    {
        Task<IEnumerable<CarModelView>> GetCarModel(int id);
        Task<IEnumerable<CarModelView>> GetCarModelMulti(string ids);
    }
}
