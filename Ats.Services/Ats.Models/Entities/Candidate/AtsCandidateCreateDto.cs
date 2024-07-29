

namespace Ats.Models.Entities.Candidate
{
    public class AtsCandidateCreateDto
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
