using LogIntelligence.Client.Extensions;
using LogIntelligence.Client.Requests;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace LogIntelligence.Client.Tests
{
    [TestClass]
    public class LogIntelligenceClientTests
    {
        private readonly ServiceProvider serviceProvider;
        private readonly LogIntelligenceClient client;
        private readonly LogIntelligenceOptions options;

        public TestContext? TestContext { get; set; }

        public LogIntelligenceClientTests()
        {
            // Create a service collection and configure the dependencies
            var services = new ServiceCollection();

            //Use the extension method to configure the LogIntelligenceClient
            services.AddLogIntelligenceClient(options =>
            {
                options.ApiKey = Guid.Parse("db7c007f-a323-4d78-9342-4322b7403bbe");
                options.LogID = Guid.Parse("db7c007f-a323-4d78-9342-4322b7403bbe");
                options.ApplicationName = "LogIntelligence.Client.Test App";
            });

            // Build the service provider
            serviceProvider = services.BuildServiceProvider();

            options = serviceProvider.GetRequiredService<IOptions<LogIntelligenceOptions>>().Value;

            // Finally, resolve the LogIntelligenceClient
            client = serviceProvider.GetRequiredService<LogIntelligenceClient>();
        }

        [TestMethod]
        public void TestLiveHostingApiClientInitialization()
        {
            Assert.IsNotNull(client, "ApiClient is null");
        }

        [TestMethod]
        public async Task TestAsyncTest()
        {
            string result = await client.TestAsync("Dan Petru");
            Assert.AreEqual("Hello Dan Petru", result);
        }

        [TestMethod]
        public async Task SendMessageAsync()
        {
            CreateLogMessageRequest req = new()
            {
                LogID=options.LogID,
                ApplicationName = options.ApplicationName,
                Timestamp=DateTimeOffset.UtcNow,
                Title = "Test Message",
                LogLevel = LogLevel.Information,
                Message = "This is a test message",
                MachineName = Environment.MachineName,
                Username= "Enter here the Username",
                Category = "Enter here the Category",
                EventID = 1,
                Exception = "Enter here the Exception",
                Version = "Enter here the Version",

            };

            await client.SendLogMessageAsync(req);
        }
    }
}