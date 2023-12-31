using CrossCutting.ConfigurationDependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulingApi
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
            ServiceDependencyInjection.ConfigureServiceDependencyInjection(services);
            RepositoryDependencyInjection.ConfigureRepositoryDependencyInjection(services);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API DE MARCA��O DE DATA NO POSTO",
                    Version = "v1",
                    Description = "Uma Api para auxiliar e facilitar no agendamento de consultas no posto de sa�de",
                    Contact = new OpenApiContact
                    {
                        Email = "tininjacms@gmail.com",
                        Name= "Christian",
                        Url = new Uri("https://github.com/Christian-M-Silva") 
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API DE MARCA��O DE DATA NO POSTO");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "api/{controller}/{id?}"
                );
            });
        }
    }
}
