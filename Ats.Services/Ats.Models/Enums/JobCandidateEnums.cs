using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models.Enums
{
    public enum SourcingTool
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

    public enum AssignedHr
    {
        Others,
        Jam,
        Khel,
        Sherlyn
    }

    public enum SalaryNegotiable
    {
        Yes,
        No
    }

    public enum NoticeDuration
    {
        OneWeekNotice,
        TwoWeeksNotice,
        ThreeWeeksNotice,
        FourWeeksOrMoreNotice
    }

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

