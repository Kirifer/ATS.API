﻿using Ats.Core.Database.Abstraction;

using ATS.Models.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ats.Datalayer.Entities
{
    public class JobCandidate : DbEntityIdBase
    {
        public Guid Id { get; set; }

        public string CsequenceNo { get; set; } // Job Candidate Number

        public string CandidateName { get; set; } // Name

        public string JobRoleId { get; set; } // Job Role Number

        public virtual JobRole JobRole { get; set; }

        public string JobName { get; set; } // Job Title (PUBLIC)

        public SourcingToolType SourceTool { get; set; } // Sourcing Tool

        public AssignedHrType AssignedHr { get; set; } // HR In-Charge

        public string CandidateEmail { get; set; } // Email Address (PUBLIC)

        public string CandidateContact { get; set; } // Contact Number (PUBLIC)

        public string CandidateCv { get; set; } // CV (PUBLIC)

        public int AskingSalary { get; set; } // Asking Gross Salary (PUBLIC)

        public string SalaryNegotiable { get; set; } // Negotiable (Yes/No) (PUBLIC)

        public int MinSalary { get; set; } // Minimum Negotiated Salary (PUBLIC)

        public int MaxSalary { get; set; } // Maximum Negotiated Salary

        public NoticeDurationType NoticeDuration { get; set; } // Availability (notice period) (PUBLIC)

        public DateOnly? DateApplied { get; set; } // Date Applied

        public DateOnly? InitialInterviewSchedule { get; set; } // Initial Interview Schedule (PUBLIC)

        public DateOnly? TechnicalInterviewSchedule { get; set; } // Technical Interview Schedule

        public DateOnly? ClientFinalInterviewSchedule { get; set; } // Client/Final Interview Schedule

        public DateOnly? BackgroundVerification { get; set; } // Background Verification

        public ApplicationStatus ApplicationStatus { get; set; } // Status (Application status)

        public int FinalSalary { get; set; } // Final Basic Salary

        public int Allowance { get; set; } // Allowances

        public string Honorarium { get; set; } // Honorarium (Basic)

        public DateOnly? JobOffer { get; set; } // Job Offer (Date)

        public DateOnly? CandidateContract { get; set; } // Job Contract (Date)
            
        public string Remarks { get; set; } // Remarks

        // Navigation Properties
        public virtual ICollection<JobCandidateAttachment> JobCandidateAttachments { get; set; }

        public virtual User User { get; set; }
    }
}
