using System.Linq;
using System.Reflection;
using Chef.BLL.MappingProfiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Chef.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterCustomServices(this IServiceCollection services)
        {
            services
                .AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.RegisterAutoMapper();
        }

        public static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetAssembly(typeof(UserProfile)));
        }
    }
}
