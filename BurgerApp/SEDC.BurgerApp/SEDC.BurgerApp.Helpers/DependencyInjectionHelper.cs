using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEDC.BurgerApp.DataAccess;
using SEDC.BurgerApp.DataAccess.EFImplementations;
using SEDC.BurgerApp.DataAccess.Implementations;
using SEDC.BurgerApp.DataAccess.Interfaces;
using SEDC.BurgerApp.Domain.Burgers;
using SEDC.BurgerApp.Domain.Orders;
using SEDC.BurgerApp.Services.Implementations;
using SEDC.BurgerApp.Services.Interfaces;

namespace SEDC.BurgerApp.Helpers
{
    public class DependencyInjectionHelper
    {
        public static void InjectRepositories(IServiceCollection services)
        {
            //Entity Framework Implementations
            //services.AddTransient<IRepository<Order>, OrderEFRepository>();
            //services.AddTransient<IRepository<Burger>, BurgerEFRepository>();
            //In memory implmentation
            services.AddTransient<IRepository<Order>, OrderRepository>();
            services.AddTransient<IRepository<Burger>, BurgerRepository>();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IBurgerService, BurgerService>();
        }

        public static void InjectDbContext(IServiceCollection services)
        {
            services.AddDbContext<BurgerAppDbContext>(options =>
            options.UseSqlServer("Server=.\\SQLEXPRESS;Database=BurgerAppDb;Trusted_Connection=True;TrustServerCertificate=true"));
        }
    }
}
