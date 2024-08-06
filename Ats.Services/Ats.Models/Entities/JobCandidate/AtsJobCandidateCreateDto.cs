using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ats.Models.Entities.JobCandidate
{
    public class AtsJobCandidateCreateDto
    {
        public Guid Id { get; set; } // GUID

        public string CandidateName { get; set; } // Name

        public string JobRoleId { get; set; } // Job Role Number

        public string JobName { get; set; } // Job Title (PUBLIC)

        public string SourceTool { get; set; } // Sourcing Tool

        public string AssignedHr { get; set; } // HR In-Charge

        public string CandidateEmail { get; set; } // Email Address (PUBLIC)

        public string CandidateContact { get; set; } // Contact Number (PUBLIC)

        public string CandidateCv { get; set; } // CV (PUBLIC)

        public int AskingSalary { get; set; } // Asking Gross Salary (PUBLIC)

        public string SalaryNegotiable { get; set; } // Negotiable (Yes/No) (PUBLIC)

        public int MinSalary { get; set; } // Minimum Negotiated Salary (PUBLIC)

        public int MaxSalary { get; set; } // Maximum Negotiated Salary

        public string NoticeDuration { get; set; } // Availability (notice period) (PUBLIC)

        public DateOnly DateApplied { get; set; } // Date Applied

        public DateOnly InitialInterviewSchedule { get; set; } // Initial Interview Schedule (PUBLIC)

        public DateOnly TechnicalInterviewSchedule { get; set; } // Technical Interview Schedule

        public DateOnly ClientFinalInterviewSchedule { get; set; } // Client/Final Interview Schedule

        public DateOnly BackgroundVerification { get; set; } // Background Verification

        public string ApplicationStatus { get; set; } // Status (Application status)

        public int FinalSalary { get; set; } // Final Basic Salary

        public int Allowance { get; set; } // Allowances

        public string Honorarium { get; set; } // Honorarium (Basic)

        public DateOnly JobOffer { get; set; } // Job Offer (Date)

        public DateOnly CandidateContract { get; set; } // Job Contract (Date)

        public string Remarks { get; set; } // Remarks

        public List<AtsJobCandidateAttachmentUploadDto>? Attachments { get; set;}
    }
}
