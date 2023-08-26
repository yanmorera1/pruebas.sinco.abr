using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Sinco.Prueba.Colegio.Application.Behaviors;
using System.Reflection;

namespace Sinco.Prueba.Colegio.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection RegisterApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
