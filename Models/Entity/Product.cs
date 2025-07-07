using System.ComponentModel.DataAnnotations;

namespace User_Products_DashBoard_MVC.Models.Entity
{
    public class Product
    {
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Product name is required")]
        public string Name { get; set; }
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Product price is required")]
        public decimal Price { get; set; }
        public int ProductCategoryId { get; set; }  
        public  ProductCategory Category { get; set; }
        public int ProductFeatureId { get; set; }
        public ProductFeature Feature { get; set; }
    }
}
