using Ats.Core.Abstraction;
using Ats.Core.Filtering;
using Ats.Datalayer.Entities;
using Ats.Datalayer.Interface;
using Ats.Domain.Services.Interface;
using Ats.Models.Entities.JobList;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Ats.Domain.Services
{
    public class JobListService : EntityService, IJobListService
    {
        private readonly IJobListRepository _joblistRepository;

        public JobListService(
            IMapper mapper,
            ILogger<JobListService> logger,

            IJobListRepository joblistRepository)
            : base(mapper, logger)
        {
            _joblistRepository = joblistRepository;
        }

        public async Task<Response<List<AtsJobListDto>>> GetJobListAsync()
        {
            try
            {
                var result = await _joblistRepository.GetAllAsync(u => true);

                var joblistDtos = new List<AtsJobListDto>();
                foreach (var joblist in result)
                {
                    var joblistDto = new AtsJobListDto
                    {
                        JobTitle = joblist.JobTitle,
                        JobLocation = joblist.JobLocation,
                        JobSetting = joblist.JobSetting,
                        JobDescription = joblist.JobDescription,
                        JobPosted = joblist.JobPosted
                    };
                    joblistDtos.Add(joblistDto); // Ensure DTOs are being added to the list
                }

                return Response<List<AtsJobListDto>>.Success(joblistDtos);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while fetching users");
                return Response<List<AtsJobListDto>>.Exception(ex);
            }
        }

        //public async Task<Response<AtsJobListDto>> CreateJobListAsync(AtsJobListCreateDto job)
        //{
        //    try
        //    {
        //        var jobList = Mapper.Map<JobList>(job); // Assuming JobList is your entity model

        //        var result = await _joblistRepository.AddAsync(jobList);

        //        var jobListDto = Mapper.Map<AtsJobListDto>(result);

        //        return Response<AtsJobListDto>.Success(jobListDto);
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError(ex, "Error occurred while creating job list.");
        //        return Response<AtsJobListDto>.Exception(ex);
        //    }
        //}

        //public async Task<Response<AtsJobListDto>> UpdateJobListAsync(Guid id, AtsJobListUpdateDto job)
        //{
        //    try
        //    {
        //        var jobList = await _joblistRepository.GetAsync(id);

        //        // Assuming direct property mapping for simplicity. Adjust as necessary.
        //        Mapper.Map(job, jobList);

        //        var result = await _joblistRepository.UpdateAsync(jobList);

        //        var jobListDto = Mapper.Map<AtsJobListDto>(result);

        //        return Response<AtsJobListDto>.Success(jobListDto);
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError(ex, "Error occurred while updating job list.");
        //        return Response<AtsJobListDto>.Exception(ex);
        //    }
        //}

        //public async Task<Response<AtsJobListDto>> DeleteJobListAsync(Guid id)
        //{
        //    try
        //    {
        //        var jobList = await _joblistRepository.GetAsync(id);

        //        var result = await _joblistRepository.DeleteAsync(jobList);

        //        var jobListDto = Mapper.Map<AtsJobListDto>(result);

        //        return Response<AtsJobListDto>.Success(jobListDto);
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError(ex, "Error occurred while deleting job list.");
        //        return Response<AtsJobListDto>.Exception(ex);
        //    }
        //}
    }
}
