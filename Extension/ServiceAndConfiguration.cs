using User_Products_DashBoard_MVC.Data;
using Microsoft.EntityFrameworkCore;
using User_Products_DashBoard_MVC.Repository;
using User_Products_DashBoard_MVC.Service;

namespace User_Products_DashBoard_MVC.Extension
{
    public static class ServiceAndConfiguration
    {
        public static IServiceCollection AddMyAppServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<CustomContext>(options =>
             options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

            return services;
        }
    }
}
