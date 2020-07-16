using System.Net;
using BusinessServices.Interfaces;
using BusinessServices.Interfaces.Validators;
using BusinessServices.Repositories;
using BusinessServices.Services.Validators;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace EmployeeApp
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCors();
            services.AddLogging();
            services.AddSwaggerGen();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<IEmployeeValidator, EmployeeValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = "docs";
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Use Cors Middleware
            app.UseCors(builder => builder.AllowAnyOrigin().AllowCredentials().AllowAnyHeader().AllowAnyMethod());

            app.UseExceptionHandler(
               builder =>
               {
                   builder.Run(
                     async context =>
                     {
                         context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                         context.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

                         var error = context.Features.Get<IExceptionHandlerFeature>();
                         if (error != null)
                         {
                             //context.Response.AddApplicationError(error.Error.Message);
                             await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                         }
                     });
               });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
