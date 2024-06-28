using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LogIntelligence.Client
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Severity
    {
        Verbose = 1,
        Debug = 2,
        Information = 3,
        Warning = 4,
        Error = 5,
        Fatal = 6
    }
}
