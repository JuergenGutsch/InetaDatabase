using System.Collections.Generic;
using Gos.Tools.Cqs.Query;
using InetaAdmin.Database.Entities;
using InetaAdmin.Infrastructure.Read.Queries;
using InetaAdmin.Infrastructure.Read.QueryHandler;
using Microsoft.Extensions.DependencyInjection;

namespace InetaAdmin.Infrastructure.Read
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddQueryHandlers(this IServiceCollection services)
        {
            services.AddTransient<IHandleQueryAsync<AllSpeakersQuery, IEnumerable<Speaker>>, SpeakerQueryHandler>();
            services.AddTransient<IHandleQueryAsync<SingleSpeakerByIdQuery, Speaker>, SpeakerQueryHandler>();

            services.AddTransient<IHandleQueryAsync<AllEventsQuery, IEnumerable<Event>>, EventQueryHandler>();
            services.AddTransient<IHandleQueryAsync<SingleEventByIdQuery, Event>, EventQueryHandler>();

            services.AddTransient<IHandleQueryAsync<AllUsergroupsQuery, IEnumerable<Usergroup>>, UsergroupQueryHandler>();
            services.AddTransient<IHandleQueryAsync<SingleUsergroupByIdQuery, Usergroup>, UsergroupQueryHandler>();

            services.AddTransient<IHandleQueryAsync<AllNewslettersQuery, IEnumerable<Newsletter>>, NewsletterQueryHandler>();
            services.AddTransient<IHandleQueryAsync<SingleNewsletterByIdQuery, Newsletter>, NewsletterQueryHandler>();
            
            return services;
        }
    }
}
