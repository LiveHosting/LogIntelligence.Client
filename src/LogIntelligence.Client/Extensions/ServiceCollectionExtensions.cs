using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIntelligence.Client.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddLogIntelligence(this IServiceCollection services, Action<LogIntelligenceOptions> configureOptions) 
        {
            services.AddOptions<LogIntelligenceOptions>()
                .Configure(configureOptions)
                .ValidateOnStart();

            services.AddHttpClient<LogIntelligenceClient>((serviceProvider, httpClient) =>
            {
                var options = serviceProvider.GetRequiredService<IOptions<LogIntelligenceOptions>>().Value;
            });

            return services;
        }
    }
}
