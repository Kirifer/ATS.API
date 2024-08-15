using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ats.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ShiftSchedule
    {
        MorningShift6AMto3PM,
        MorningShift7AMto4PM,
        RegularShift8AMto5PM,
        RegularShift9AMto6PM,
        MidShift3PMto12MN,
        NightShift9PMto6AM,
        NightShift10PMto7AM
    }
}
