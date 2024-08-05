using Ats.Core.Abstraction;
using Ats.Core.Filtering;
using Ats.Datalayer.Entities;
using Ats.Datalayer.Implementation;
using Ats.Datalayer.Interface;
using Ats.Domain.Services.Interface;
using Ats.Models.Entities.JobCandidate;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ats.Domain.Services
{
    public class JobCandidateService : EntityService, IJobCandidateService
    {
        private readonly IJobCandidateRepository _jobCandidateRepository;

        public JobCandidateService (
            IMapper mapper,
            ILogger<JobCandidateService> logger,
            IJobCandidateRepository jobCandidateRepository)
            : base (mapper, logger)
        {
            _jobCandidateRepository = jobCandidateRepository;
        }

        public async Task<Response<List<AtsJobCandidateDto>>> GetJobCandidatesAsync(AtsJobCandidateFilterDto filter)
        {
            try
            {
                var result = await _jobCandidateRepository.GetAllAsync(candidate => true);

                var candidateDtoList = Mapper.Map<List<AtsJobCandidateDto>>(result);

                return Response<List<AtsJobCandidateDto>>.Success(candidateDtoList);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while fetching candidates");
                return Response<List<AtsJobCandidateDto>>.Exception(ex);
            }
        }

        public async Task<Response<AtsJobCandidateDto>> GetJobCandidateAsync(Guid id)
        {
            try
            {
                var result = await _jobCandidateRepository.GetAsync(id);
                var candidateDtoList = Mapper.Map<AtsJobCandidateDto>(result);
                return Response<AtsJobCandidateDto>.Success(candidateDtoList);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while fetching candidate with id.");
                return Response<AtsJobCandidateDto>.Exception(ex);
            }
        }

        public async Task<Response<AtsJobCandidateDto>> CreateJobCandidateAsync(AtsJobCandidateCreateDto candidate)
        {
            try
            {
                var createRef = Mapper.Map<JobCandidate>(candidate);

                // Get the next sequence number from the repository
                var csequenceNo = await _jobCandidateRepository.GetLatestSequenceNo();

                // Set the sequence number to the job candidate
                createRef.CsequenceNo = csequenceNo;

                // Add the job candidate
                var result = await _jobCandidateRepository.AddAsync(createRef);

                // Map the result to DTO
                var candidateDto = Mapper.Map<AtsJobCandidateDto>(result);

                return Response<AtsJobCandidateDto>.Success(candidateDto);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while creating candidate.");
                return Response<AtsJobCandidateDto>.Exception(ex);
            }
        }


        public async Task<Response<AtsJobCandidateDto>> UpdateJobCandidateAsync(Guid id, AtsJobCandidateUpdateDto candidate)
        {
            try
            {
                var updateRef = await _jobCandidateRepository.GetAsync(id);


                updateRef.CandidateName = candidate.CandidateName;
                updateRef.JobRoleId = candidate.JobRoleId; // Added JobRoleId
                updateRef.JobName = candidate.JobName; // Added JobName
                updateRef.SourceTool = candidate.SourceTool; // Fixed to match schema
                updateRef.AssignedHr = candidate.AssignedHr;
                updateRef.CandidateEmail = candidate.CandidateEmail;
                updateRef.CandidateContact = candidate.CandidateContact;
                updateRef.AskingSalary = candidate.AskingSalary;
                updateRef.SalaryNegotiable = candidate.SalaryNegotiable;
                updateRef.MinSalary = candidate.MinSalary;
                updateRef.MaxSalary = candidate.MaxSalary;
                updateRef.NoticeDuration = candidate.NoticeDuration;
                updateRef.DateApplied = candidate.DateApplied; // Added DateApplied
                updateRef.InitialInterviewSchedule = candidate.InitialInterviewSchedule; // Added InitialInterviewSchedule
                updateRef.TechnicalInterviewSchedule = candidate.TechnicalInterviewSchedule; // Added TechnicalInterviewSchedule
                updateRef.ClientFinalInterviewSchedule = candidate.ClientFinalInterviewSchedule; // Added ClientFinalInterviewSchedule
                updateRef.BackgroundVerification = candidate.BackgroundVerification; // Added BackgroundVerification
                updateRef.ApplicationStatus = candidate.ApplicationStatus;
                updateRef.FinalSalary = candidate.FinalSalary;
                updateRef.Allowance = candidate.Allowance;
                updateRef.Honorarium = candidate.Honorarium;
                updateRef.JobOffer = candidate.JobOffer;
                updateRef.CandidateContract = candidate.CandidateContract;
                updateRef.Remarks = candidate.Remarks;


                var result = await _jobCandidateRepository.UpdateAsync(updateRef);

                var candidateDto = Mapper.Map<AtsJobCandidateDto>(result);

                return Response<AtsJobCandidateDto>.Success(candidateDto);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while updating candidate.");
                return Response<AtsJobCandidateDto>.Exception(ex);
            }
        }

        public async Task<Response<AtsJobCandidateDto>> DeleteJobCandidateAsync(Guid id)
        {
            try
            {
                var deleteRef = await _jobCandidateRepository.GetAsync(id);

                var result = await _jobCandidateRepository.DeleteAsync(deleteRef);

                var candidateDto = Mapper.Map<AtsJobCandidateDto>(result);

                return Response<AtsJobCandidateDto>.Success(candidateDto);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while deleting candidate.");
                return Response<AtsJobCandidateDto>.Exception(ex);
            }
        }

    }
}
