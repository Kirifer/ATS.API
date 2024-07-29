using AutoMapper;
using Ats.Core.Abstraction;
using Ats.Domain.Services.Interface;
using Ats.Datalayer.Interface;
using Microsoft.Extensions.Logging;
using Ats.Core.Filtering;
using Ats.Datalayer.Entities;
using Ats.Models.Entities.Recruitment;

namespace Ats.Domain.Services
{
    public class RecruitmentService : EntityService, IRecruitmentService
    {
        private readonly IRecruitmentRepository _recruitmentRepository;

        public RecruitmentService(
            IMapper mapper,
            ILogger<RecruitmentService> logger,
            IRecruitmentRepository recruitmentRepository)
            : base(mapper, logger)
        {
            _recruitmentRepository = recruitmentRepository;
        }

        public async Task<Response<List<AtsRecruitmentDto>>> GetRecruitmentsAsync(AtsRecruitmentFilterDto filter)
        {
            try
            {
                var result = await _recruitmentRepository.GetAllAsync(recruit => true);

                var recruitmentDtoList = Mapper.Map<List<AtsRecruitmentDto>>(result);

                return Response<List<AtsRecruitmentDto>>.Success(recruitmentDtoList);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while fetching recruits");
                return Response<List<AtsRecruitmentDto>>.Exception(ex);
            }
        }

        public async Task<Response<AtsRecruitmentDto>> GetRecruitmentAsync(Guid id)
        {
            try
            {
                var result = await _recruitmentRepository.GetAsync(id);
                var recruitmentDtoList = Mapper.Map<AtsRecruitmentDto>(result);
                return Response<AtsRecruitmentDto>.Success(recruitmentDtoList);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while fetching recruit with id.");
                return Response<AtsRecruitmentDto>.Exception(ex);
            }
        }

        public async Task<Response<AtsRecruitmentDto>> CreateRecruitmentAsync(AtsRecruitmentCreateDto recruit)
        {
            try
            {
                var createRef = Mapper.Map<Recruitment>(recruit);

                var result = await _recruitmentRepository.AddAsync(createRef);

                var recruitmentDto = Mapper.Map<AtsRecruitmentDto>(result);

                return Response<AtsRecruitmentDto>.Success(recruitmentDto);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while creating recruit.");
                return Response<AtsRecruitmentDto>.Exception(ex);
            }
        }

        public async Task<Response<AtsRecruitmentDto>> UpdateRecruitmentAsync(Guid id, AtsRecruitmentUpdateDto recruit)
        {
            try
            {
                var updateRef = await _recruitmentRepository.GetAsync(id);

                updateRef.CandidateName = recruit.CandidateName;
                updateRef.CandidateCv = recruit.CandidateCv;
                updateRef.CandidateEmail = recruit.CandidateEmail;
                updateRef.CandidateContact = recruit.CandidateContact;
                updateRef.SourceTool = recruit.SourceTool;
                updateRef.AssignedHr = recruit.AssignedHr;
                updateRef.AskingSalary = recruit.AskingSalary;
                updateRef.SalaryNegotiable = recruit.SalaryNegotiable;
                updateRef.MinSalary = recruit.MinSalary;
                updateRef.MaxSalary = recruit.MaxSalary;
                updateRef.NoticeDuration = recruit.NoticeDuration;
                updateRef.ApplicationStatus = recruit.ApplicationStatus;
                updateRef.FinalSalary = recruit.FinalSalary;
                updateRef.Allowance = recruit.Allowance;
                updateRef.Honorarium = recruit.Honorarium;
                updateRef.JobOffer = recruit.JobOffer;
                updateRef.CandidateContract = recruit.CandidateContract;
                updateRef.Remarks = recruit.Remarks;


                var result = await _recruitmentRepository.UpdateAsync(updateRef);

                var recruitmentDto = Mapper.Map<AtsRecruitmentDto>(result);

                return Response<AtsRecruitmentDto>.Success(recruitmentDto);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while updating recruit.");
                return Response<AtsRecruitmentDto>.Exception(ex);
            }
        }

        public async Task<Response<AtsRecruitmentDto>> DeleteRecruitmentAsync(Guid id)
        {
            try
            {
                var deleteRef = await _recruitmentRepository.GetAsync(id);

                var result = await _recruitmentRepository.DeleteAsync(deleteRef);

                var recruitmentDto = Mapper.Map<AtsRecruitmentDto>(result);

                return Response<AtsRecruitmentDto>.Success(recruitmentDto);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while deleting recruit.");
                return Response<AtsRecruitmentDto>.Exception(ex);
            }
        }

    }
}
