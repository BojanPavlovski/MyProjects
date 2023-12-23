using LibraryManagementSystem.DataAccess;
using LibraryManagementSystem.DataAccess.Implementations;
using LibraryManagementSystem.DataAccess.Interfaces;
using LibraryManagementSystem.Services.Implementations;
using LibraryManagementSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagementSystem.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(IServiceCollection services)
        {
            services.AddDbContext<LibraryManagementSystemDbContext>(x => x.UseSqlServer("Server=.\\SQLEXPRESS;Database=LibraryAppDb;Trusted_Connection=True;TrustServerCertificate=True"));
        }

        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRentInfoRepository, RentInfoRepository>();
            services.AddTransient<IAdminRepository, AdminRepository>();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRentInfoService, RentInfoService>();
            services.AddTransient<IAdminService, AdminService>();
        }
    }
}
