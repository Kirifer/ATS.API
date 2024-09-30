using Ats.Shared.Models;
using Ats.Models.Entities.JobCandidate;

namespace Ats.Models
{
    public class AtsUserDto : EntityBaseDto
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public virtual ICollection<AtsJobCandidateDto> JobCandidates { get; set; } = new List<AtsJobCandidateDto>();
    }
}
