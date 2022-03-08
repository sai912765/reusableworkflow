using AutomobileAPI.BusinessLayer;
using AutomobileAPI.DataLayer;
using AutomobileAPI.Repository;
using AutomobileAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AutomobileAPI.Business
{
    public class ProcessCarMake : IProcessCarMake
    {
        private readonly ICarMakeDAL carMakeDAL;
        private readonly AutomobileDbContext _context;

        public ProcessCarMake(AutomobileDbContext context)
        {
            carMakeDAL = new CarMakeDAL(context);
        }

        public Task<IEnumerable<CarMakeView>> GetCarMakes()
        {
            return carMakeDAL.GetCarMakes();
        }
        public Task<CarMakeView> GetCarMakes(int id)
        {
            return carMakeDAL.GetCarMakes(id);
        }
    }
}
