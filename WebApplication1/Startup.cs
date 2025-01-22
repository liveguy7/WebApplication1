using System;
using System.Diagnostics;

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

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
                              ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                logger.LogInformation("MW1: incoming..");
                await next();
                logger.LogInformation("MW1: outgoing..");
            });

            app.Use(async (context, next) =>
            {
                logger.LogInformation("MW2: incoming..");
                await next();
                logger.LogInformation("MW2: outgoing..");
            });

            app.Run(async (context) =>
            {
                await context.Response
                    .WriteAsync("Jello!");
                logger.LogInformation("MW3!");
            });
        }
    }

}


