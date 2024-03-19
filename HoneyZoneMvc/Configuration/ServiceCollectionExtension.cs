
using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.BusinessLogic.Services;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.BusinessLogic.AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HoneyZoneMvc.Infrastructure.Data.Models.IdentityModels;
using Microsoft.Extensions.Options;
namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection services, IConfiguration config)
        {
            services = AddContext(services, config);
            services = AddIdentityWithRoles(services);
            services = AddServices(services);
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICartProductService, CartProductService>();
            services.AddScoped<IDeliveryService, DeliveryService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IUserService, UserService>();
            services.AddAutoMapper(typeof(Program), typeof(ProductProfile));
            return services;
        }
        private static IServiceCollection AddContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;

        }
        private static IServiceCollection AddIdentityWithRoles(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>(services =>
            {
                services.SignIn.RequireConfirmedAccount = false;
                services.SignIn.RequireConfirmedPhoneNumber = false;
                services.Password.RequireDigit = false;
                services.Password.RequireNonAlphanumeric = false;
                services.Password.RequireUppercase = false;
            })
            .AddRoles<ApplicationRole>()
           .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllersWithViews();

            return services;
        }
    }
}