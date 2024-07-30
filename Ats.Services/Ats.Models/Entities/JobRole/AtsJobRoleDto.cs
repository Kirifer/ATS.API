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
        public string? JobName { get; set; }

        public string? HiringType { get; set; }

        public string? JobDescription { get; set; }

        public string? RoleLevel { get; set; }

        public string? JobLocation { get; set; }

        public string? ShiftSched { get; set; }

        public string? JobStatus { get; set; }
    }
}
