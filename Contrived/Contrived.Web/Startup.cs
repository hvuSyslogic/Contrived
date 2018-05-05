using Contrived.Data.Persistence;
using Contrived.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services
                .AddMiniProfiler(options =>
                {
                    //options.ShowControls = true;

                    //options.ShouldProfile = (httpRequest) => httpRequest.QueryString.HasValue;
                    
                    options.TrackConnectionOpenClose = false;
                })
                .AddEntityFramework()
                ;

            services.AddDbContext<ContrivedContext>(options =>
            {
                options.UseSqlServer("server=localhost\\sql2014;database=dbContrived;Trusted_Connection=yes");
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
}
