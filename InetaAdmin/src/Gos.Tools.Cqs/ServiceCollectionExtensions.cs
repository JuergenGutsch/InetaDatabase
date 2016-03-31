using System;
using Gos.Tools.Cqs.Command;
using Gos.Tools.Cqs.Query;
using Microsoft.Extensions.DependencyInjection;

namespace Gos.Tools.Cqs
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCqsEngine(this IServiceCollection services)
        {
            services.AddScoped<IQueryProcessor, QueryProcessor>();
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();

            return services;
        }


        public static IServiceCollection AddCqsEngine(this IServiceCollection services, Action<IServiceCollection> subRegister)
        {
            services.AddScoped<IQueryProcessor, QueryProcessor>();
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();

            subRegister(services);

            return services;
        }
    }
}
