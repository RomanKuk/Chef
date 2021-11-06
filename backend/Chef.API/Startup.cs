using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Chef.API.Extensions;
using Chef.API.Filters;
using Chef.API.Middleware;
using Chef.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.FileProviders;

namespace Chef.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            IdentityModelEventSource.ShowPII = true;

            //services
            //    .AddControllers()
            //    .AddFluentValidation(fv =>
            //        fv.RegisterValidatorsFromAssemblyContaining<UserDtoValidator>());

            var migrationAssembly = typeof(ChefContext).Assembly.GetName().Name;
            services.AddDbContext<ChefContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DBConnection"), opt => opt.MigrationsAssembly(migrationAssembly)));

            services.AddHealthChecks();

            services.RegisterCustomServices();

            services.AddMemoryCache();

            services.AddCors(options =>
            {
                options.AddPolicy("AnyOrigin", x => x
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var firebaseProjectName = Configuration["FirebaseProjectName"];
                    options.Authority = "https://securetoken.google.com/" + firebaseProjectName;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "https://securetoken.google.com/" + firebaseProjectName,
                        ValidateAudience = true,
                        ValidAudience = firebaseProjectName,
                        ValidateLifetime = true
                    };
                });


            services.AddMvcCore(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AnyOrigin");

            app.UseMiddleware<GenericExceptionHandlerMiddleware>();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });

            InitializeFileProvider(app);
            InitializeDatabase(app);
        }

        private static void InitializeFileProvider(IApplicationBuilder app)
        {
            var resourcesPath = Path.Combine(Directory.GetCurrentDirectory(), @"Resources");
            Directory.CreateDirectory(resourcesPath);

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(resourcesPath),
                RequestPath = new PathString("/Resources")
            });
        }

        private static void InitializeDatabase(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
            if (scope == null) return;
            using var context = scope.ServiceProvider.GetRequiredService<ChefContext>();
            context.Database.Migrate();
        }
    }
}
