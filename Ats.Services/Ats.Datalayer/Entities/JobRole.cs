using Ats.Core.Database.Abstraction;
using Ats.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ats.Datalayer.Entities
{
    public class JobRole : DbEntityIdBase
    {
        public Guid Id { get; set; }

        public string SequenceNo { get; set; }

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

        public DateOnly? OpenDate { get; set; } // Open Date

        public DateOnly? ClosedDate { get; set; }

        public int DaysCovered { get; set; }

        public string Aging { get; set; }

        public virtual List<JobCandidate> Candidates { get; set; }
    }
}
