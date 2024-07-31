using Ats.Datalayer.Entities;
using Ats.Datalayer.Interface;
using Microsoft.EntityFrameworkCore;
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

        public async Task<int> GetLatestSequenceNo()
        {
            //Get All Job Candidates
            // Use ToList() to load all records in memory
            var jobcandidates = Context.JobCandidates.AsNoTracking().ToList();

            if (jobcandidates == null || jobcandidates.Count == 0)
            {

                return 0;
            }
            //Get Max Sequence No
            var maxSequenceNo = jobcandidates.Max(c => c.CsequenceNo);

            //Return Max Sequence No
            return maxSequenceNo;

        }
    }
}
