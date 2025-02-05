using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LogIntelligence.Client.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddLogIntelligenceClient(this IServiceCollection services, Action<LogIntelligenceOptions> configure)
        {
            ArgumentNullException.ThrowIfNull(services);
            ArgumentNullException.ThrowIfNull(configure);

            services.AddOptionsWithValidateOnStart<LogIntelligenceOptions>();
            
            services.Configure(configure);
            //services.AddOptions<LogIntelligenceOptions>().Configure(configureOptions).ValidateOnStart();

            services.AddHttpClient<LogIntelligenceClient>((serviceProvider, client) =>
            {
                var options = serviceProvider.GetRequiredService<IOptions<LogIntelligenceOptions>>().Value;

                client.DefaultRequestHeaders.Add("X-API-KEY", options.ApiKey.ToString());
                client.DefaultRequestVersion = new Version(2, 0);

                client.BaseAddress = new Uri("https://api.logint.ro/");
            });

            return services;
        }
    }
}
