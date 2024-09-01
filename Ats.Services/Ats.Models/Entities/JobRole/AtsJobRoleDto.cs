using Ats.Models.Entities.JobCandidate;
using Ats.Models.Enums;
using Ats.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ats.Models.Entities.JobRole
{
    public class AtsJobRoleDto : EntityBaseDto
    {
        public Guid? Id { get; set; }

        public string? SequenceNo { get; set; } // Job Role No.

        public string? JobName { get; set; } // Job Title

        public string? ClientShortcodes { get; set; } // Client Shortcodes

        public HiringManager? HiringManager { get; set; } // Hiring Manager

        public string? SalesManager { get; set; } // Sales Manager

        public HiringType? HiringType { get; set; } // Type of Hiring

        public string? JobDescription { get; set; } // Job Description

        public RoleLevel? RoleLevel { get; set; } // Role Level

        public int? MinSalary { get; set; } // Minimum Salary

        public int? MaxSalary { get; set; } // Maximum Salary

        public JobLocation? JobLocation { get; set; } // Location

        public ShiftSchedule? ShiftSched { get; set; } // Schedule

        public JobStatus? JobStatus { get; set; } // Status

        public DateOnly? ClosedDate { get; set; } // Closed Date

        public DateOnly? OpenDate { get; set; } // Open Date

        public int? DaysCovered { get; set; } // Using int to store the number of days (Days Covered)

        public string? Aging { get; set; } // Default value for aging (Aging)

        public List<AtsJobCandidateDto>? Candidates { get; set; }
    }
}
