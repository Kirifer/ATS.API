using System.Text.Json.Serialization;

namespace ATS.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum NoticeDurationType
    {
        OneWeekNotice,
        TwoWeeksNotice,
        ThreeWeeksNotice,
        FourWeeksOrMoreNotice
    }
}