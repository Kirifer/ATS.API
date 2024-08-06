using Ats.Datalayer.Entities;
using Ats.Datalayer.Interface;

namespace Ats.Datalayer.Implementation
{
    public class JobCandidateAttachmentRepository : BaseRepository<JobCandidateAttachment>, IJobCandidateAttachmentRepository
    {
        public JobCandidateAttachmentRepository(AtsDbContext dbContext) : base(dbContext) { }

    }
}
