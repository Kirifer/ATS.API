using System.Text.Json.Serialization;

namespace ATS.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SourcingToolType
    {
        JobStreet,
        Referral,
        LinkedIn,
        Indeed,
        Facebook,
        Jora,
        Email,
        OJT,
        Others
    }
}

