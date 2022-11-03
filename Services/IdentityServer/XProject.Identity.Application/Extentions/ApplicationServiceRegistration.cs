using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace XProject.Identity.Application.Extentions
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddScoped<IIdentityRepository, IdentityRepository>();

            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            //services.AddMassTransit(config => {
            //    config.UsingRabbitMq((ctx, cfg) => {
            //        cfg.Host(configuration["EventBusSettings:HostAddress"]);
            //        //cfg.UseHealthCheck(ctx);
            //    });
            //});
            //services.AddMassTransitHostedService();

            services.AddHealthChecks()
                .AddSqlServer(configuration.GetConnectionString("DefaultConnection"), "SELECT 1;", null);
                

            return services;

        }
    }
}
