using AutomobileAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AutomobileAPI.BusinessLayer
{
    public interface IProcessCarMake
    {
        Task<IEnumerable<CarMakeView>> GetCarMakes();
        Task<CarMakeView> GetCarMakes(int id);
    }
}
