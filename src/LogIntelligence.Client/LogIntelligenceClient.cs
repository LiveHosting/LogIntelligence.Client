using Microsoft.Extensions.Logging;

namespace LogIntelligence.Client
{
    public partial class LogIntelligenceClient
    {
        private readonly ILogger<LogIntelligenceClient> logger;
        private readonly HttpClient http;
        private readonly LogIntelligenceOptions options;

        public LogIntelligenceClient(ILogger<LogIntelligenceClient> Logger, HttpClient HttpClient, LogIntelligenceOptions Options)
        {
            this.logger = Logger ?? throw new ArgumentNullException(nameof(Logger));
            this.http = HttpClient ?? throw new ArgumentNullException(nameof(HttpClient));
            this.options = Options ?? throw new ArgumentNullException(nameof(Options));
        }
    }
}
