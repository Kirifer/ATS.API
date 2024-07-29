using Ats.Core.Abstraction;
using Ats.Core.Filtering;
using Ats.Datalayer.Entities;
using Ats.Datalayer.Interface;
using Ats.Domain.Services.Interface;
using Ats.Models.Entities.Candidate;
using AutoMapper;
using Microsoft.Extensions.Logging;


namespace Ats.Domain.Services
{
    public class CandidateService : EntityService, ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateService(
            IMapper mapper,
            ILogger<CandidateService> logger,
            ICandidateRepository candidateRepository)
            : base(mapper, logger)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<Response<List<AtsCandidateDto>>> GetCandidatesAsync(AtsCandidateFilterDto filter)
        {
            try
            {
                var result = await _candidateRepository.GetAllAsync(candidate => true);

                var candidateDtoList = Mapper.Map<List<AtsCandidateDto>>(result);

                return Response<List<AtsCandidateDto>>.Success(candidateDtoList);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while fetching users");
                return Response<List<AtsCandidateDto>>.Exception(ex);
            }
        }

        public async Task<Response<AtsCandidateDto>> GetCandidateAsync(Guid id)
        {
            try
            {
                var result = await _candidateRepository.GetAsync(id);
                var candidateDtoList = Mapper.Map<AtsCandidateDto>(result);
                return Response<AtsCandidateDto>.Success(candidateDtoList);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while fetching user with id.");
                return Response<AtsCandidateDto>.Exception(ex);
            }
        }

        public async Task<Response<AtsCandidateDto>> CreateCandidateAsync(AtsCandidateCreateDto candidate)
        {
            try
            {
                var createRef = Mapper.Map<Candidate>(candidate);

                var result = await _candidateRepository.AddAsync(createRef);

                var candidateDto = Mapper.Map<AtsCandidateDto>(result);

                return Response<AtsCandidateDto>.Success(candidateDto);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while creating candidate.");
                return Response<AtsCandidateDto>.Exception(ex);
            }
        }

        public async Task<Response<AtsCandidateDto>> UpdateCandidateAsync(Guid id, AtsCandidateUpdateDto candidate)
        {
            try
            {
                var updateRef = await _candidateRepository.GetAsync(id);

                updateRef.JobName = candidate.JobName;
                updateRef.ClientShortcodes = candidate.ClientShortcodes;
                updateRef.HiringManager = candidate.HiringManager;
                updateRef.JobName = candidate.JobName;
                updateRef.SalesManager = candidate.SalesManager;
                updateRef.HiringType =  candidate.HiringType;
                updateRef.JobDescription = candidate.JobDescription;
                updateRef.RoleLevel = candidate.RoleLevel;
                updateRef.MinSalary = candidate.MinSalary;
                updateRef.MaxSalary = candidate.MaxSalary;
                updateRef.JobLocation = candidate.JobLocation;
                updateRef.ShiftSched = candidate.ShiftSched;
                updateRef.JobStatus = candidate.JobStatus;


                var result = await _candidateRepository.UpdateAsync(updateRef);

                var candidateDto = Mapper.Map<AtsCandidateDto>(result);

                return Response<AtsCandidateDto>.Success(candidateDto);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while updating user.");
                return Response<AtsCandidateDto>.Exception(ex);
            }
        }

        public async Task<Response<AtsCandidateDto>> DeleteCandidateAsync(Guid id)
        {
            try
            {
                var deleteRef = await _candidateRepository.GetAsync(id);

                var result = await _candidateRepository.DeleteAsync(deleteRef);

                var candidateDto = Mapper.Map<AtsCandidateDto>(result);

                return Response<AtsCandidateDto>.Success(candidateDto);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while deleting user.");
                return Response<AtsCandidateDto>.Exception(ex);
            }
        }

    }
}
