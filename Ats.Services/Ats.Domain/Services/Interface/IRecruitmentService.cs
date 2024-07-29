using Ats.Core.Abstraction;
using Ats.Core.Filtering;
using Ats.Models.Entities.Recruitment;

namespace Ats.Domain.Services.Interface
{
    public interface IRecruitmentService : IEntityService
    {
        Task<Response<List<AtsRecruitmentDto>>> GetRecruitmentsAsync(AtsRecruitmentFilterDto filter);

        Task<Response<AtsRecruitmentDto>> GetRecruitmentAsync(Guid id);

        Task<Response<AtsRecruitmentDto>> CreateRecruitmentAsync(AtsRecruitmentCreateDto recruit);

        Task<Response<AtsRecruitmentDto>> UpdateRecruitmentAsync(Guid id, AtsRecruitmentUpdateDto recruit);

        Task<Response<AtsRecruitmentDto>> DeleteRecruitmentAsync(Guid id);
    }
}
