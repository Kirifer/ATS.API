using System.Text.Json.Serialization;

namespace Ats.Shared.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AccessFilterType
    {
        None = 0,
        Admin,
        Applicant,
    }
}
