using Microsoft.Extensions.Options;

namespace LogIntelligence.Client
{
    public partial class LogIntelligenceClient
    {
        private readonly HttpClient _http;

        public LogIntelligenceClient(HttpClient httpClient)
        {
            _http = httpClient;

            //_http.BaseAddress = new Uri("https://localhost:7290/");
            //_http.DefaultRequestHeaders.Add("X-API-KEY", _options.ApiKey.ToString());
            //_http.DefaultRequestVersion = new Version(2, 0);
        }

        public async Task<string> TestAsync(string Name)
        {
            HttpResponseMessage response = await _http.GetAsync($"Test/Test?Name={Name}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
