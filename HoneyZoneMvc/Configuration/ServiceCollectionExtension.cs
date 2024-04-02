﻿
using HoneyZoneMvc.BusinessLogic.AutoMapper;
using HoneyZoneMvc.BusinessLogic.Contracts.ServiceContracts;
using HoneyZoneMvc.BusinessLogic.Services;
using HoneyZoneMvc.Data;
using HoneyZoneMvc.Infrastructure.Data.Models.IdentityModels;
using HoneyZoneMvc.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            services.AddScoped<IStatisticService, StatisticService>();
            services.AddScoped<IFileStorageService, FileStorageService>();
            services.AddAutoMapper(typeof(Program), typeof(MyProfile));
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
                services.Password.RequireDigit = true;
                services.Password.RequireNonAlphanumeric = false;
                services.Password.RequireUppercase = false;
                services.Password.RequiredLength = 6;
            })
            .AddRoles<ApplicationRole>()
           .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllersWithViews(options =>
            {
                options.ModelBinderProviders.Insert(0, new DoubleModelBinderProvider());
                options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
            });

            return services;
        }
    }
}