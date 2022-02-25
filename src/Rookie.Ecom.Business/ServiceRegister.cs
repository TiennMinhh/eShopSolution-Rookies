using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Business.Services;
using Rookie.Ecom.DataAccessor;
using System.Reflection;
using Refit;
using System;

namespace Rookie.Ecom.Business
{
    public static class ServiceRegister
    {
        public static void AddBusinessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataAccessorLayer(configuration);
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderItemService, OrderItemService>();
            services.AddTransient<IProductFeedBackService, ProductFeedBackService>();
            services.AddTransient<IProductPictureService, ProductPictureService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<ISlideService, SlideService>();
            services.AddTransient<IUserService, UserService>();

            services.AddRefitClient<IIdentityProviderService>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:5001"));
        }
    }
}