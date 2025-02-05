namespace LogIntelligence.Client
{
    public class LogIntelligenceOptions
    {
        public required Guid ApiKey { get; set; }
        public required Guid LogID { get; set; }
        public required string ApplicationName { get; set; }
    }
}
