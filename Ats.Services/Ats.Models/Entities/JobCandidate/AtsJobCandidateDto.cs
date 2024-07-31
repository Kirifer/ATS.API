using Ats.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ats.Models.Entities.JobCandidate
{
    public class AtsJobCandidateDto : EntityBaseDto
    {
        public string? CandidateName { get; set; } // Name

        public string? JobRoleId { get; set; } // Job Role Number

        public string? JobName { get; set; } // Job Title (PUBLIC)

        public string? SourceTool { get; set; } // Sourcing Tool

        public string? AssignedHr { get; set; } // HR In-Charge

        public string? CandidateEmail { get; set; } // Email Address (PUBLIC)

        public string? CandidateContact { get; set; } // Contact Number (PUBLIC)

        public int? AskingSalary { get; set; } // Asking Gross Salary (PUBLIC)

        public string? SalaryNegotiable { get; set; } // Negotiable (Yes/No) (PUBLIC)

        public int? MinSalary { get; set; } // Minimum Negotiated Salary (PUBLIC)

        public int? MaxSalary { get; set; } // Maximum Negotiated Salary

        public string? NoticeDuration { get; set; } // Availability (notice period) (PUBLIC)

        public DateTime? DateApplied { get; set; } // Date Applied

        public DateTime? InitialInterviewSchedule { get; set; } // Initial Interview Schedule (PUBLIC)

        public DateTime? TechnicalInterviewSchedule { get; set; } // Technical Interview Schedule

        public DateTime? ClientFinalInterviewSchedule { get; set; } // Client/Final Interview Schedule

        public DateTime? BackgroundVerification { get; set; } // Background Verification

        public string? ApplicationStatus { get; set; } // Status (Application status)

        public int? FinalSalary { get; set; } // Final Basic Salary

        public int? Allowance { get; set; } // Allowances

        public string? Honorarium { get; set; } // Honorarium (Basic)

        public DateTime? JobOffer { get; set; } // Job Offer (Date)

        public DateTime? CandidateContract { get; set; } // Job Contract (Date)

        public string? Remarks { get; set; } // Remarks
    }
}
