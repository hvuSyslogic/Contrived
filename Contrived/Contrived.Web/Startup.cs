using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            services.AddMiniProfiler(options =>
            {
                options.SqlFormatter = new StackExchange.Profiling.SqlFormatters.SqlServerFormatter();
            });

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
