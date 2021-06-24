using FootballersCatalog.Infrastructure.Data;
using FootballersCatalog.Interfaces.RepositoryInterfaces;
using FootballersCatalog.Services.Interfaces;
using FootballersCatalog.Services.Validation;
using FootballersCatalog.Web.SignalR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FootballersCatalog.Web
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
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IValidation, FootballerModelValidation>();
            services.AddSignalR();
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chat",
                    options =>
                    {
                        options.ApplicationMaxBufferSize = 64;
                        options.TransportMaxBufferSize = 64;
                        options.LongPolling.PollTimeout = System.TimeSpan.FromMinutes(1);
                        options.Transports = HttpTransportType.LongPolling | HttpTransportType.WebSockets;
                    });

                //endpoints.MapControllerRoute(
                //   name: "default",
                //   pattern: "{controller=Footballer}/{action=AddFootballer}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Footballer}/{action=AddFootballer}/{id?}");
            });
        }
    }
}
