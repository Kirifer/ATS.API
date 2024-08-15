using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ats.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum HiringType
    {
        Additional,
        Replacement
    }
}
