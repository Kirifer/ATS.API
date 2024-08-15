using Ats.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ats.Models.Entities.JobRole
{
    public class AtsJobRoleCreateDto
    {
        public Guid Id { get; set; }

        public string JobName { get; set; } // Job Title

        public string ClientShortcodes { get; set; } // Client Shortcodes

        public HiringManager HiringManager { get; set; } // Hiring Manager

        public string SalesManager { get; set; } // Sales Manager

        public HiringType HiringType { get; set; } // Type of Hiring

        public string JobDescription { get; set; } // Job Description

        public RoleLevel RoleLevel { get; set; } // Role Level

        public int MinSalary { get; set; } // Minimum Salary

        public int MaxSalary { get; set; } // Maximum Salary

        public JobLocation JobLocation { get; set; } // Location

        public ShiftSchedule ShiftSched { get; set; } // Schedule

        public JobStatus JobStatus { get; set; } // Status
    }
}
