using System;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using WebApplication1.Models;

namespace WebApplication1
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;

        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
                       options.EnableEndpointRouting = false);
            services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                DeveloperExceptionPageOptions dEPO = new DeveloperExceptionPageOptions()
                {
                    SourceCodeLineCount = 1
                };
                app.UseDeveloperExceptionPage(dEPO);
            }
            else
            {
                app.UseExceptionHandler("Error Found");
            }

            //DefaultFilesOptions dFO = new DefaultFilesOptions();
            //dFO.DefaultFileNames.Clear();
            //dFO.DefaultFileNames.Add("abc.html");
            //app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                //throw new Exception("Error Found. Please Contact the Admin");
                await context.Response
                    .WriteAsync("Error Found. Please Contact the Admin.");
                  
                
            });
        }
    }

}



