using Ats.Core.Database.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ats.Datalayer.Entities
{
    public class Candidate : DbEntityIdBase
    {
        public required string JobName { get; set; }

        public required string ClientShortcodes { get; set; }

        public required string HiringManager { get; set; }

        public required string SalesManager { get; set; }

        public required string HiringType { get; set; }

        public required string JobDescription { get; set; }

        public required string RoleLevel { get; set; }

        public required int MinSalary { get; set; }

        public required int MaxSalary { get; set; }

        public required string JobLocation { get; set; }

        public required string ShiftSched { get; set; }

        public required string JobStatus { get; set; }

        public required DateOnly ClosedDate { get; set; }
    }
}
