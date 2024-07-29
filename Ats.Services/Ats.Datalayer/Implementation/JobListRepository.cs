using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ats.Datalayer.Entities;
using Ats.Datalayer.Interface;

namespace Ats.Datalayer.Implementation
{
    public class JobListRepository : BaseRepository<JobList>, IJobListRepository
    {
        public JobListRepository(AtsDbContext context) : base(context)
        {
        }
    }
}
