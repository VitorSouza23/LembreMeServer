using AutoMapper;
using LembreMeServer.Domain.Repository;
using LembreMeServer.Infra.Context;
using LembreMeServer.Infra.Repository;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;

namespace LembreMeServer.API
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
            services.AddControllers();

            Assembly domainAssembly = AppDomain.CurrentDomain.Load("LembreMeServer.Domain");
            services.AddAutoMapper(Assembly.GetExecutingAssembly(), domainAssembly);
            services.AddMediatR(Assembly.GetExecutingAssembly(), domainAssembly);

            services.AddSingleton<IAppContext, EFContext>();
            services.AddSingleton<ITaskRepository, TaskRepository>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
