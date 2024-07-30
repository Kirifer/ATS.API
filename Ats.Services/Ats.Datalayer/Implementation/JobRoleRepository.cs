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
            //Get All Job Roles
            // Use ToList() to load all records in memory
            var jobroles = Context.JobRoles.AsNoTracking().ToList();

            if (jobroles == null || jobroles.Count == 0) 
            { 
            
                return 0;
            }
            //Get Max Sequence No
            var maxSequenceNo = jobroles.Max(r => r.SequenceNo);

            //Return Max Sequence No
            return maxSequenceNo;

        }


    }
}
