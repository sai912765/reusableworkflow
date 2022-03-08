namespace AutomobileAPI.ViewModels
{
    public class CarForSaleView
    {
        public int CarForSaleId { get; set; }
        public int? CarModelId { get; set; }
        public string? CarMakeName { get; set; }
        public string? CarModelName { get; set; }
        public int? Miles { get; set; }
        public decimal? Ratings { get; set; }
        public string? ZipCode { get; set; }
        public string? SellerName { get; set; }
        public string? SellerContactDetails { get; set; }
        public decimal? Price { get; set; }
        public string? Color { get; set; }
        public string? Image { get; set; }
    }
}
