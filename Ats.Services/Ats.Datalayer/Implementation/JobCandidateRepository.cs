using Ats.Datalayer.Entities;
using Ats.Datalayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ats.Datalayer.Implementation
{
    public class JobCandidateRepository : BaseRepository<JobCandidate>, IJobCandidateRepository
    {
        public JobCandidateRepository(AtsDbContext dbContext) : base(dbContext) { }
    }
}
