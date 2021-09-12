using ContactManagement.Bll.Core.Interfaces;
using ContactManagement.Bll.Services;
using ContactManagement.Dal.Providers;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ContactManagement.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private static readonly TimeSpan _timeout = TimeSpan.FromSeconds(300);
        private static readonly IAsyncPolicy<HttpResponseMessage> RetryPolicy = HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(2),
                    TimeSpan.FromSeconds(3)
                }
            );

        public static IServiceCollection AddDependencyInjections(this IServiceCollection services)
        {
            services.AddScoped<IContactProvider, ContactProvider>();
            services.AddScoped<IContactService, ContactService>();
            return services;
        }
    }
}
