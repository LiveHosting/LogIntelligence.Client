using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace LogIntelligence.Client
{
    public partial class LogIntelligenceClient
    {
        public async Task SendMessageAsync(CreateMessageRequest body)
        {
            HttpResponseMessage response = await http.PostAsJsonAsync("Messages/CreateMessage", body);
            response.EnsureSuccessStatusCode();
        }
    }
}
