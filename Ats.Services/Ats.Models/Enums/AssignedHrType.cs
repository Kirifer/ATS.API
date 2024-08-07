using System.Text.Json.Serialization;

namespace ATS.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AssignedHrType
    {
        Others,
        Jam,
        Khel,
        Sherlyn
    }
}

