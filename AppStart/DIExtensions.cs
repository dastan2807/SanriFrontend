using Microsoft.Extensions.DependencyInjection;
using SanriJP.API.Service;
using System;

namespace SanriJP.API.AppStart
{
    public static class DIExtensions
    {
        public static void AddCustomDI(this IServiceCollection services)
        {
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IAuctionService, AuctionService>();
            services.AddTransient<ICarOrderService, CarOrderService>();
            services.AddTransient<ICarModelService, CarModelService>();
            services.AddTransient<ICarResaleService, CarResaleService>();
            services.AddTransient<ICarSaleService, CarSaleService>();
        }
    }
}
