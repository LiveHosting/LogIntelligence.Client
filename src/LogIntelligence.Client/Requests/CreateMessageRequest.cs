namespace LogIntelligence.Client.Requests
{
    public record CreateLogMessageRequest
    {
        public required Guid LogID { get; init; }
        public required string Title { get; init; }
        public required DateTimeOffset Timestamp { get; init; }
        public required LogLevel LogLevel { get; init; }
        public int? EventID { get; init; }
        public string? EventName { get; init; }
        public required string Message { get; init; }
        public string? Exception { get; init; }
        public string? Source { get; init; }
        public string? Category { get; init; }
        public string? Properties { get; init; }
        public required string MachineName { get; init; }
        public required string ApplicationName { get; init; }
        public int? StatusCode { get; init; }
        public string? Username { get; init; }
        public string? Url { get; init; }
        public string? Method { get; init; }
        public required string Version { get; init; }
        public string? CorrelationID { get; init; }
        public ICollection<KeyValuePair<string, string>>? Cookies { get; init; }
        public ICollection<KeyValuePair<string, string>>? Form { get; init; }
        public ICollection<KeyValuePair<string, string>>? QueryString { get; init; }
        public ICollection<KeyValuePair<string, string>>? ServerVariables { get; init; }
    }
}
