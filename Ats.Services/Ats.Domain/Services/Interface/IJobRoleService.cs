using Ats.Core.Abstraction;
using Ats.Core.Filtering;
using Ats.Models.Entities.JobRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ats.Domain.Services.Interface
{
    public interface IJobRoleService : IEntityService
    {
        Task<Response<List<AtsJobRoleDto>>> GetJobRolesAsync(AtsJobRoleFilterDto filter);

        Task<Response<AtsJobRoleDto>> GetJobRoleAsync(Guid id);

        Task<Response<AtsJobRoleDto>> CreateJobRoleAsync(AtsJobRoleCreateDto role);

        Task<Response<AtsJobRoleDto>> UpdateJobRoleAsync(Guid id, AtsJobRoleUpdateDto role);

        Task<Response<AtsJobRoleDto>> DeleteJobRoleAsync(Guid id);
    }
}
