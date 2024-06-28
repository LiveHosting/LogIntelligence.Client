using LogIntelligence.Client.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace LogIntelligence.Client.Tests
{
    [TestClass]
    public class LogIntelligenceClientTests
    {
        private readonly ServiceProvider serviceProvider;
        private readonly LogIntelligenceClient client;
        private readonly HttpContext context;
        private readonly LogIntelligenceOptions options;

        public TestContext? TestContext { get; set; }

        public LogIntelligenceClientTests()
        {
            // Create a service collection and configure the dependencies
            var services = new ServiceCollection();

            services.AddHttpContextAccessor();

            //Use the extension method to configure the LogIntelligenceClient
            services.AddLogIntelligence(options =>
            {
                options.ApiKey = new Guid("db7c007f-a323-4d78-9342-4322b7403bbe");
                options.LogID = new Guid("db7c007f-a323-4d78-9342-4322b7403bbe");
                options.Application = "LogIntelligence.Client.Test App";
            });

            // Build the service provider
            serviceProvider = services.BuildServiceProvider();

            // Set up HttpContext with claims before making requests
            SetupHttpContext();

            options = serviceProvider.GetRequiredService<IOptions<LogIntelligenceOptions>>().Value;

            // Finally, resolve the LogIntelligenceClient
            client = serviceProvider.GetRequiredService<LogIntelligenceClient>();
        }

        private void SetupHttpContext()
        {
            var claims = new List<Claim>
            {
                new Claim("UserID", "1", ClaimValueTypes.Integer32 ),
                new Claim("Username", "test123", ClaimValueTypes.String),
                new Claim(ClaimTypes.Name, "test123", ClaimValueTypes.String)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var user = new ClaimsPrincipal(identity);
            var context = new DefaultHttpContext
            {
                User = user
            };

            var httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            httpContextAccessor.HttpContext = context;
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
            CreateMessageRequest req = new()
            {
                LogID=options.LogID,
                Application = "LogIntelligence.Client.Test App",
                Hostname = "Hostname",
                User = "Username here",
                CreatedDate = DateTime.UtcNow,
                Url = "url here",
                Code = "sgd sdg sd",
                Form = new List<MessageItem>()
                 {
                     new MessageItem("Key1", "Value1")
                 },
                Cookies = new List<MessageItem>()
                 {
                     new MessageItem("Cookie1", "Cookie1 Value")
                 },
                Detail = "sdgsdg",
                Method = "Get",
                ServerVariables = new List<MessageItem>()
                   {
                       new MessageItem("ServerVariable1","ServerVariable1 Value")
                   },
                Title = "TITLE",
                Version = "1.0.0",
                Type = "TYPE",
                QueryString = new List<MessageItem>()
                    {
                        new MessageItem("q1", "q1 value")
                    },
                Severity = Severity.Warning,
                StatusCode = StatusCodes.Status500InternalServerError,
                Source = "Source here",
                CorrelationID=Guid.NewGuid().ToString(),
            };

            await client.SendMessageAsync(req);
        }
    }
}