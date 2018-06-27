using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace JCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            //testing for pull request to GitHub
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
                
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();

                //Development environment error handle
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //Environment setup by "Properties -> launchSetting.json"
                //Production environment error handle
                app.UseExceptionHandler("/Shared/Error");
            }

            app.UseStaticFiles();

            //app.UseMvc();
            //Use MVC and setting the default router
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Index}/{id?}");
            });

            app.UseMvcWithDefaultRoute();
        }
    }
}
