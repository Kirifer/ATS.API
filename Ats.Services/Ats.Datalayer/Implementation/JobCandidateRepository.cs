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

        public async Task<string> GetLatestSequenceNo()
        {
            // Get All Job Candidates
            var jobCandidates = Context.JobCandidates.AsNoTracking().ToList();

            if (jobCandidates == null || jobCandidates.Count == 0)
            {
                // Return the first sequence number if no records exist
                return "JC-00001";
            }

            // Extract the numeric part from the sequence numbers
            var sequenceNos = jobCandidates
                .Select(c => c.CsequenceNo)
                .Where(seq => seq.StartsWith("JC-"))
                .Select(seq =>
                {
                    var numberPart = seq.Substring(3); // Remove "JC-"
                    return int.TryParse(numberPart, out var num) ? num : 0;
                });

            // Get Max Sequence Number
            var maxSequenceNo = sequenceNos.Any() ? sequenceNos.Max() : 0;

            // Format the result as "JC-000X" with leading zeros
            var nextSequenceNo = maxSequenceNo + 1;
            return $"JC-{nextSequenceNo:D5}"; // Format as "JC-00001", "JC-00002", etc.
        }

        public async Task<JobCandidate?> GetJobCandidateDetailsAsync(Guid id)
        {
            return await Context.JobCandidates.AsNoTracking()
                .Include(c => c.JobCandidateAttachments)
                .Include(c => c.User)  // Eager load the related User
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<JobCandidate>> GetJobCandidatesAsync()
        {
            return await Context.JobCandidates.AsNoTracking()
                .Include(c => c.JobRole)
                .Include(c => c.User)  // Eager load User as well
                .Include(c => c.JobCandidateAttachments)
                .ToListAsync();
        }

        public async Task<JobCandidate?> GetJobCandidateByEmailAsync(string email) 
        {
            return await Context.JobCandidates.AsNoTracking()
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.CandidateEmail == email);
        }
    }
}
