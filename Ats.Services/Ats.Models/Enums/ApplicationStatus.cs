using System.Text.Json.Serialization;

namespace ATS.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ApplicationStatus
    {
        InitialInterview,
        TechnicalInterview,
        ClientInterview,
        NoShow,
        NotShortlisted,
        RetractedApplication,
        WaitingForSuitableClient,
        Blacklisted,
        SalesAdvice,
        CongratulatoryEmail,
        JobOffer,
        ContractPreparation,
        Onboarded
    }
}

