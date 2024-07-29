using Ats.Shared.Models;

namespace Ats.Models.Entities.Candidate
{
    public class AtsCandidateDto : EntityBaseDto
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
