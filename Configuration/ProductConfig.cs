using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User_Products_DashBoard_MVC.Models.Entity;

namespace User_Products_DashBoard_MVC.Configuration
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(c => c.Name).HasMaxLength(30);
        }
    }
}
