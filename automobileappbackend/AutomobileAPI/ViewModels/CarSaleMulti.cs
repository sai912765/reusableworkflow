using Microsoft.AspNetCore.Mvc;

namespace AutomobileAPI.ViewModels
{
    [BindProperties]
    public class CarSaleMulti
    {
        public List<int> CarModelIds { get; set; }
        public List<string> Zipcodes { get; set; }
    }
}
