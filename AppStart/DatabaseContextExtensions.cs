using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SanriJP.API.DataContext;

namespace SanriJP.API.AppStart
{
    public static class DatabaseContextExtensions
    {
        public static void AddCustomSqlContext(this IServiceCollection services, IConfiguration configuration)
        =>  services.AddDbContext<AppDbContext>(p => p.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }
}
