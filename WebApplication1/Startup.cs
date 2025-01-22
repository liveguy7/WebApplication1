using System;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;

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
                app.UseExceptionHandler("Error Found!!");
            }

            DefaultFilesOptions dFO = new DefaultFilesOptions();
            dFO.DefaultFileNames.Clear();
            dFO.DefaultFileNames.Add("abc.html");
            app.UseDefaultFiles(dFO);
            app.UseStaticFiles();

            app.Run(async (context) =>
            {
                //throw new Exception("Error Found. Please Contact the Admin");
                await context.Response
                    .WriteAsync("Error Found. Please Contact the Admin " + env.EnvironmentName);
                  
                
            });
        }
    }

}





