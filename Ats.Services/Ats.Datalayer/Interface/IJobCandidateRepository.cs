using Ats.Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ats.Datalayer.Interface
{
    public interface IJobCandidateRepository : IBaseRepository<JobCandidate>
    {
        Task<string> GetLatestSequenceNo();
    }
}
