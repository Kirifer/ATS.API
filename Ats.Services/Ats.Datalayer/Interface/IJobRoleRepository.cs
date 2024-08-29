using Ats.Datalayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ats.Datalayer.Interface
{
    public interface IJobRoleRepository : IBaseRepository<JobRole>
    {
        Task<string> GetLatestSequenceNo();

        Task<List<JobRole>> GetAllJobRolesAsync();
    }
}
