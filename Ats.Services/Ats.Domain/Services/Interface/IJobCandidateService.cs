using Ats.Core.Abstraction;
using Ats.Core.Filtering;
using Ats.Models.Entities.JobCandidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ats.Domain.Services.Interface
{
    public interface IJobCandidateService : IEntityService
    {
        Task<Response<List<AtsJobCandidateDto>>> GetJobCandidatesAsync(AtsJobCandidateFilterDto filter);

        Task<Response<AtsJobCandidateDto>> GetJobCandidateAsync(Guid id);

        Task<Response<AtsJobCandidateDto>> CreateJobCandidateAsync(AtsJobCandidateCreateDto candidate);

        Task<Response<AtsJobCandidateDto>> UpdateJobCandidateAsync(Guid id, AtsJobCandidateUpdateDto candidate);

        Task<Response<AtsJobCandidateDto>> DeleteJobCandidateAsync(Guid id);
    }
}
