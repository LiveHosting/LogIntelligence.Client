using LogIntelligence.Client.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace LogIntelligence.Client.Tests
{
    [TestClass]
    public class LogIntelligenceClientTests
    {
        private readonly ServiceProvider serviceProvider;
        private readonly LogIntelligenceClient client;

        public LogIntelligenceClientTests()
        {
            // Create a service collection and configure the dependencies
            var services = new ServiceCollection();

            //Use the extension method to configure the LogIntelligenceClient
            services.AddLogIntelligence(options=> 
            {
                options.ApiKey = new Guid("db7c007f-a323-4d78-9342-4322b7403bbe");
                options.LogID = new Guid("db7c007f-a323-4d78-9342-4322b7403bbe");
            });

            // Build the service provider
            serviceProvider = services.BuildServiceProvider();

            // Finally, resolve the LogIntelligenceClient
            client = serviceProvider.GetRequiredService<LogIntelligenceClient>();
        }

        [TestMethod]
        public void TestLiveHostingApiClientInitialization()
        {
            Assert.IsNotNull(client, "ApiClient is null");
        }
    }
}