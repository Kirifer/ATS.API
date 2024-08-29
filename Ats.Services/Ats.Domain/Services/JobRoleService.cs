using Ats.Core.Abstraction;
using Ats.Core.Filtering;
using Ats.Datalayer.Entities;
using Ats.Datalayer.Implementation;
using Ats.Datalayer.Interface;
using Ats.Domain.Services.Interface;
using Ats.Models.Entities.JobCandidate;
using Ats.Models.Entities.JobRole;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ats.Domain.Services
{
    public class JobRoleService : EntityService, IJobRoleService
    {
        private readonly IJobRoleRepository _jobRoleRepository;

        public JobRoleService (
            IMapper mapper,
            ILogger<JobRoleService> logger,
            IJobRoleRepository jobRoleRepository )
            : base( mapper, logger )
        {
            _jobRoleRepository = jobRoleRepository;
        }

        public async Task<Response<List<AtsJobRoleDto>>> GetJobRolesAsync(AtsJobRoleFilterDto filter)
        {
            try
            {
                var result = await _jobRoleRepository.GetAllJobRolesAsync();

                var roleDtoList = Mapper.Map<List<AtsJobRoleDto>>(result);

                return Response<List<AtsJobRoleDto>>.Success(roleDtoList);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while fetching roles");
                return Response<List<AtsJobRoleDto>>.Exception(ex);
            }
        }

        public async Task<Response<AtsJobRoleDto>> GetJobRoleAsync(Guid id)
        {
            try
            {
                var result = await _jobRoleRepository.GetAsync(id);
                var roleDtoList = Mapper.Map<AtsJobRoleDto>(result);
                return Response<AtsJobRoleDto>.Success(roleDtoList);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while fetching role with id.");
                return Response<AtsJobRoleDto>.Exception(ex);
            }
        }

        public async Task<Response<AtsJobRoleDto>> CreateJobRoleAsync(AtsJobRoleCreateDto role)
        {
            try
            {
                var createRef = Mapper.Map<JobRole>(role);

                createRef.OpenDate = DateOnly.FromDateTime(DateTime.UtcNow);

                // Get the next sequence number from the repository
                var sequenceNo = await _jobRoleRepository.GetLatestSequenceNo();

                // Set the sequence number to the job candidate
                createRef.SequenceNo = sequenceNo;

                // Add the job candidate
                var result = await _jobRoleRepository.AddAsync(createRef);

                // Map the result to DTO
                var roleDto = Mapper.Map<AtsJobRoleDto>(result);

                return Response<AtsJobRoleDto>.Success(roleDto);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while creating role.");
                return Response<AtsJobRoleDto>.Exception(ex);
            }
        }

        public async Task<Response<AtsJobRoleDto>> UpdateJobRoleAsync(Guid id, AtsJobRoleUpdateDto role)
        {
            try
            {
                var updateRef = await _jobRoleRepository.GetAsync(id);

                updateRef.JobName = role.JobName;
                updateRef.ClientShortcodes = role.ClientShortcodes;
                updateRef.HiringManager = role.HiringManager;
                updateRef.JobName = role.JobName;
                updateRef.SalesManager = role.SalesManager;
                updateRef.HiringType = role.HiringType;
                updateRef.JobDescription = role.JobDescription;
                updateRef.RoleLevel = role.RoleLevel;
                updateRef.MinSalary = role.MinSalary;
                updateRef.MaxSalary = role.MaxSalary;
                updateRef.JobLocation = role.JobLocation;
                updateRef.ShiftSched = role.ShiftSched;
                updateRef.JobStatus = role.JobStatus;
                updateRef.ClosedDate = role.ClosedDate;


                var result = await _jobRoleRepository.UpdateAsync(updateRef);

                var roleDto = Mapper.Map<AtsJobRoleDto>(result);

                return Response<AtsJobRoleDto>.Success(roleDto);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while updating role.");
                return Response<AtsJobRoleDto>.Exception(ex);
            }
        }

        public async Task<Response<AtsJobRoleDto>> DeleteJobRoleAsync(Guid id)
        {
            try
            {
                var deleteRef = await _jobRoleRepository.GetAsync(id);

                var result = await _jobRoleRepository.DeleteAsync(deleteRef);

                var roleDto = Mapper.Map<AtsJobRoleDto>(result);

                return Response<AtsJobRoleDto>.Success(roleDto);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while deleting role.");
                return Response<AtsJobRoleDto>.Exception(ex);
            }
        }




    }
}
