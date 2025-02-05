using LogIntelligence.Client.Requests;
using System.Net.Http.Json;

namespace LogIntelligence.Client
{
    public partial class LogIntelligenceClient
    {
        public async Task SendLogMessageAsync(CreateLogMessageRequest body)
        {
            HttpResponseMessage response = await _http.PostAsJsonAsync("Messages/CreateLogMessage", body);
            //response.EnsureSuccessStatusCode();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
