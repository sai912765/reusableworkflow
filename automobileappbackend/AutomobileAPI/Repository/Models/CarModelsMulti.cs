using Microsoft.EntityFrameworkCore;

namespace AutomobileAPI.Repository.Models
{
    [Keyless]
    public class CarModelsMulti
    {
        public int CarModelId { get; set; }

        public int CarMakeID { get; set; }
        public string CarModelName { get; set; } = null!;
        public string carMakeModel { get; set; } = null!;
    }
}
