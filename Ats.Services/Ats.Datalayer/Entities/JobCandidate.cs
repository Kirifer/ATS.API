using Ats.Core.Database.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ats.Datalayer.Entities
{
    public class JobCandidate : DbEntityIdBase
    {
        public int CsequenceNo { get; set; } // Job Candidate Number

        public required string CandidateName { get; set; } // Name

        public required string JobRoleId { get; set; } // Job Role Number

        public required string JobName { get; set; } // Job Title (PUBLIC)

        public required string SourceTool { get; set; } // Sourcing Tool

        public required string AssignedHr { get; set; } // HR In-Charge

        public required string CandidateEmail { get; set; } // Email Address (PUBLIC)

        public required string CandidateContact { get; set; } // Contact Number (PUBLIC)

        public required int AskingSalary { get; set; } // Asking Gross Salary (PUBLIC)

        public required string SalaryNegotiable { get; set; } // Negotiable (Yes/No) (PUBLIC)

        public required int MinSalary { get; set; } // Minimum Negotiated Salary (PUBLIC)

        public required int MaxSalary { get; set; } // Maximum Negotiated Salary

        public required string NoticeDuration { get; set; } // Availability (notice period) (PUBLIC)

        public required DateTime DateApplied { get; set; } // Date Applied

        public required DateTime InitialInterviewSchedule { get; set; } // Initial Interview Schedule (PUBLIC)

        public required DateTime TechnicalInterviewSchedule { get; set; } // Technical Interview Schedule

        public required DateTime ClientFinalInterviewSchedule { get; set; } // Client/Final Interview Schedule

        public required DateTime BackgroundVerification { get; set; } // Background Verification

        public required string ApplicationStatus { get; set; } // Status (Application status)

        public required int FinalSalary { get; set; } // Final Basic Salary

        public required int Allowance { get; set; } // Allowances

        public required string Honorarium { get; set; } // Honorarium (Basic)

        public required DateTime JobOffer { get; set; } // Job Offer (Date)

        public required DateTime CandidateContract { get; set; } // Job Contract (Date)

        public required string Remarks { get; set; } // Remarks
    }
}
