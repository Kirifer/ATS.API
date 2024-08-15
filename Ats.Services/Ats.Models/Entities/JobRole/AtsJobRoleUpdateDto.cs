using Ats.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ats.Models.Entities.JobRole
{
    public class AtsJobRoleUpdateDto
    {
        public string JobName { get; set; }

        public string ClientShortcodes { get; set; }

        public HiringManager HiringManager { get; set; }

        public string SalesManager { get; set; }

        public HiringType HiringType { get; set; }

        public string JobDescription { get; set; }

        public RoleLevel RoleLevel { get; set; }

        public int MinSalary { get; set; }

        public int MaxSalary { get; set; }

        public JobLocation JobLocation { get; set; }

        public ShiftSchedule ShiftSched { get; set; }

        public JobStatus JobStatus { get; set; }

        public DateOnly? ClosedDate { get; set; }
    }
}
