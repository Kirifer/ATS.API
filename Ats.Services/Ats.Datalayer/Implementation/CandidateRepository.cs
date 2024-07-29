using Ats.Datalayer.Entities;
using Ats.Datalayer.Interface;

namespace Ats.Datalayer.Implementation
{
    public class CandidateRepository : BaseRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(AtsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
