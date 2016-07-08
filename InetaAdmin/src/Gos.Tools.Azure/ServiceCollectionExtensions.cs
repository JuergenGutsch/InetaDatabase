using System;
using System.Spatial;
using Microsoft.Extensions.DependencyInjection;

namespace Gos.Tools.Azure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddStorageClient(
            this IServiceCollection services,
            StorageAccountCredentials storageCredentials)
        {
            if (storageCredentials == null)
            {
                throw new ArgumentNullException(nameof(storageCredentials));
            }

            services.AddSingleton<ITableClient>(new TableClient(storageCredentials));

            return services;
        }
    }
}
