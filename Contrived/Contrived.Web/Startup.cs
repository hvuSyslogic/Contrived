using Contrived.Data.Persistence;
using Contrived.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Profiling.Storage;

namespace Contrived.Web
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
            var connectionString = Configuration.GetConnectionString("Contrived");

            var miniProfilerSettings = Configuration.GetSection("MiniProfiler").Get<MiniProfilerSettings>();
            services
                .AddMiniProfiler(options =>
                {
                    //options.ShowControls = true;

                    //options.ShouldProfile = (httpRequest) => httpRequest.QueryString.HasValue;
                    options.ShouldProfile = (request) => miniProfilerSettings.Enabled;
                    
                    options.TrackConnectionOpenClose = false;

                    //options.Storage = new SqlServerStorage(connectionString);
                })
                .AddEntityFramework()
                ;

            services.AddDbContext<ContrivedContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            
            services.AddTransient<BlogService>();
            services.AddTransient<MathService>();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            
            app.UseStaticFiles();

            app.UseMiniProfiler();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }

    public class MiniProfilerSettings
    {
        public bool Enabled { get; set; }
    }
}
