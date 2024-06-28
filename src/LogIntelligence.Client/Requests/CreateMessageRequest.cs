using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIntelligence.Client
{
    public class CreateMessageRequest
    {
        public Guid LogID { get; set; }
        public string Application { get; set; }
        public string Detail { get; set; }
        public string Hostname { get; set; }
        public string Title { get; set; }
        public string Source { get; set; }
        public int? StatusCode { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string Type { get; set; }
        public string User { get; set; }
        public Severity? Severity { get; set; }
        public string Url { get; set; }
        public string Method { get; set; }
        public string Version { get; set; }
        public string CorrelationID { get; set; }
        public string Code { get; set; }
        public ICollection<MessageItem> Cookies { get; set; }
        public ICollection<MessageItem> Form { get; set; }
        public ICollection<MessageItem> QueryString { get; set; }
        public ICollection<MessageItem> ServerVariables { get; set; }
    }
}
