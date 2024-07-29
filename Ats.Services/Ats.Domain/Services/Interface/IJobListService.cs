using Ats.Core.Filtering;
using Ats.Core.Abstraction;
using Ats.Models.Entities.JobList;

namespace Ats.Domain.Services.Interface
{
    public interface IJobListService : IEntityService
    {
        Task<Response<List<AtsJobListDto>>> GetJobListAsync();

        //Task<Response<AtsJobListDto>> GetJobListAsync(Guid id);

        //Task<Response<AtsJobListDto>> CreateJobListAsync(AtsJobListCreateDto job);

        //Task<Response<AtsJobListDto>> UpdateJobListAsync(Guid id, AtsJobListUpdateDto job);

        //Task<Response<AtsJobListDto>> DeleteJobListAsync(Guid id);
    }
}
