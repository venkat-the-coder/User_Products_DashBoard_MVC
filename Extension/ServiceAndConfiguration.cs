using User_Products_DashBoard_MVC.Data;
using Microsoft.EntityFrameworkCore;

namespace User_Products_DashBoard_MVC.Extension
{
    public static class ServiceAndConfiguration
    {
        public static IServiceCollection AddMyAppServices(this IServiceCollection services, IConfiguration config)
        {
             services.AddDbContext<CustomContext>(options =>
              options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
