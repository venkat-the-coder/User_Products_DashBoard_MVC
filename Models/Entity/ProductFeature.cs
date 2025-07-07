namespace User_Products_DashBoard_MVC.Models.Entity
{
    public class ProductFeature
    {
        public int Id { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }
        public Product Product { get; set; }

    }
}
