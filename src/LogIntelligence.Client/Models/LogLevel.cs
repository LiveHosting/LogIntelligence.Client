using System.Text.Json.Serialization;

namespace LogIntelligence.Client
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum LogLevel
    {
        Verbose = 1,
        Debug = 2,
        Information = 3,
        Warning = 4,
        Error = 5,
        Fatal = 6
    }
}
