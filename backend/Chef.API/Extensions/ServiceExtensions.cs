using System.Linq;
using System.Reflection;
using Chef.BLL.Interfaces;
using Chef.BLL.MappingProfiles;
using Chef.BLL.Providers;
using Chef.BLL.Services;
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

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRecipeService, RecipeService>();

            services.AddTransient<IFileProvider, FileProvider>();

            services.RegisterAutoMapper();
        }

        public static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetAssembly(typeof(UserProfile)));
        }
    }
}
