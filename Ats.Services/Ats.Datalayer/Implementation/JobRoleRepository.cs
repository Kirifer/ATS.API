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

        public async Task<int> GetLatestSequenceNo()
        {
            var jobroles = Context.JobRoles.AsNoTracking().ToList();

            var maxSequenceNo = jobroles.Max(r => r.SequenceNo);

            return maxSequenceNo;

        }


    }
}
