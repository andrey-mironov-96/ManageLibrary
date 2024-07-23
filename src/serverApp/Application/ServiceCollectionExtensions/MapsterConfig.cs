using Application.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace Application.ServiceCollectionExtensions
{
    public static class MapsterConfig
    {
        public static void AddCustomMapsterConfig(this IServiceCollection services)
        {
            services.AddSingleton<BookcaseMapsterConfig>();
            services.AddSingleton<ShelfMapsterConfig>();
        }
    }
}
