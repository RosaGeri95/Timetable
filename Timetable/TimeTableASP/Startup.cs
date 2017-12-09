using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TimetableInterfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using TimetableService.Service;

namespace TimeTableASP
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
            services.AddMvc();
            services.AddLogging();
            services.AddDbContext<TimeTableContext>(options=> options.UseSqlServer(Configuration.GetConnectionString("TimeTableContext")));
            services.AddTransient<ICalendarService, CalendarService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                 "Default",                                              // Route name
                 "{controller}/{action}/{id}",                           // URL with parameters
                 new { controller = "TimeTable", action = "TimeTable", id = "" }  // Parameter defaults
             );
            });
        }
    }
}
