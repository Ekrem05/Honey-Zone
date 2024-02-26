
using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.BusinessLogic.Services;
using HoneyZoneMvc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection services,IConfiguration config)
        {
           
           
            services=AddContext(services,config);
            services=AddIdentityWithRoles(services);
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
            services.AddScoped<IStateService, StateService>();
            services.AddScoped<IImageService, ImageService>();
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
            services.AddDefaultIdentity<IdentityUser>(options => 
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
           .AddEntityFrameworkStores<ApplicationDbContext>();
            return services;
        }
    }
}
