using Ats.Core.Abstraction;
using Ats.Core.Filtering;
using Ats.Models.Entities.Candidate;

namespace Ats.Domain.Services.Interface
{
    public interface ICandidateService : IEntityService
    {
        Task<Response<List<AtsCandidateDto>>> GetCandidatesAsync(AtsCandidateFilterDto filter);

        Task<Response<AtsCandidateDto>> GetCandidateAsync(Guid id);

        Task<Response<AtsCandidateDto>> CreateCandidateAsync(AtsCandidateCreateDto job);

        Task<Response<AtsCandidateDto>> UpdateCandidateAsync(Guid id, AtsCandidateUpdateDto job);

        Task<Response<AtsCandidateDto>> DeleteCandidateAsync(Guid id);
    }
}
