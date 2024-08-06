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
    public class JobRoleRepository : BaseRepository<JobRole>, IJobRoleRepository
    {
        public JobRoleRepository(AtsDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<string> GetLatestSequenceNo()
        {
            // Get All Job Roles
            var jobRoles = Context.JobRoles.AsNoTracking().ToList();

            if (jobRoles == null || jobRoles.Count == 0)
            {
                // Return the first sequence number if no records exist
                return "JR-00001";
            }

            // Extract the numeric part from the sequence numbers
            var sequenceNos = jobRoles
                .Select(r => r.SequenceNo)
                .Where(seq => seq.StartsWith("JR-"))
                .Select(seq =>
                {
                    var numberPart = seq.Substring(3); // Remove "JR-"
                    return int.TryParse(numberPart, out var num) ? num : 0;
                });

            // Get Max Sequence Number
            var maxSequenceNo = sequenceNos.Any() ? sequenceNos.Max() : 0;

            // Format the result as "JR-000X" with leading zeros
            var nextSequenceNo = maxSequenceNo + 1;
            return $"JR-{nextSequenceNo:D5}"; // Format as "JR-00001", "JR-00002", etc.
        }


    }
}
