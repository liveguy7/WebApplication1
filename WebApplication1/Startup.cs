﻿using System;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

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
            services.AddDbContextPool<AppDbContext>(options =>
                              options.UseSqlServer(_config.GetConnectionString("WebApplicationDBConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            //services.Configure<IdentityOptions>(options =>
            //{
            //    //options.Password.RequiredLength = 10;
            //    //options.Password.RequireNonAlphanumeric = false;

            //});

            services.AddMvc(options =>
                       options.EnableEndpointRouting = false);
            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();

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
                app.UseExceptionHandler("/Error");
                //app.UseStatusCodePagesWithRedirects("/Error/{0}");
            }

            //DefaultFilesOptions dFO = new DefaultFilesOptions();
            //dFO.DefaultFileNames.Clear();
            //dFO.DefaultFileNames.Add("abc.html");
            //app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthentication();
            //app.UseMvc(routes =>
            //{
                //routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            //});
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



