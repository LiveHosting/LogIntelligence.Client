using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LogIntelligence.Client
{
    public partial class LogIntelligenceClient
    {
        private readonly ILogger<LogIntelligenceClient> logger;
        private readonly HttpClient http;
        private readonly LogIntelligenceOptions options;

        public LogIntelligenceClient(ILogger<LogIntelligenceClient> Logger, HttpClient HttpClient, IOptions<LogIntelligenceOptions> Options)
        {
            this.logger = Logger ?? throw new ArgumentNullException(nameof(Logger));
            this.http = HttpClient ?? throw new ArgumentNullException(nameof(HttpClient));
            this.options = Options.Value ?? throw new ArgumentNullException(nameof(Options));

            http.BaseAddress = new Uri("https://localhost:7290/");
        }

        public async Task<string> TestAsync(string Name)
        {
            HttpResponseMessage response = await http.GetAsync($"Test/Test?Name={Name}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
