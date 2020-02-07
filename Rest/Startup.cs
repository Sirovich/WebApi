using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rest.Api.Middleware;
using Rest.DataLayer.Screens.Contexts;
using Rest.DataLayer.Screens.Repositories;
using Rest.Logic.ScreensLogic;

namespace Rest.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            #region DbContexts

            services.AddDbContext<ScreenContext>(op => op.UseSqlServer(Configuration["ConnectionStrings:ScreensDbConnectionString"]));

            #endregion

            #region Logics

            services.AddScoped<IScreenLogic, ScreenLogic>();

            #endregion

            #region Repositories

            services.AddScoped<IScreenRepository, ScreenRepository>();

            #endregion

            services.AddMemoryCache();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
