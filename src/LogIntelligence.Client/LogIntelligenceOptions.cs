using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIntelligence.Client
{
    public class LogIntelligenceOptions
    {
        public required Guid ApiKey { get; set; }
        public Guid LogID { get; set; }
        public string Application { get; set; }
    }
}
