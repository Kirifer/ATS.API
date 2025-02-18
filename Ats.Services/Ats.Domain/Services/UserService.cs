﻿
using System.Net;

using Ats.Core.Abstraction;
using Ats.Core.Filtering;
using Ats.Datalayer;
using Ats.Datalayer.Entities;
using Ats.Datalayer.Implementation;
using Ats.Datalayer.Interface;
using Ats.Domain.Services.Interface;
using Ats.Models;
using Ats.Models.Entities.JobCandidate;
using Ats.Shared.Enums;

using AutoMapper;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ats.Domain.Services
{
    public class UserService: EntityService, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJobCandidateService _jobCandidateService;

        public UserService(
            IMapper mapper,
            ILogger<UserService> logger,

            IUserRepository userRepository, IJobCandidateService jobCandidateService)
            : base(mapper, logger)
        {
            _userRepository = userRepository;
            _jobCandidateService = jobCandidateService;
        }

        public async Task<Response<List<AtsUserDto>>> GetUsersAsync(AtsUserFilterDto filter)
        {
            try
            {
                var result = await _userRepository.GetAllAsync(u =>
                string.IsNullOrEmpty(filter.Username) || u.Username == filter.Username);

                var userDtos = Mapper.Map<List<AtsUserDto>>(result);

                return Response<List<AtsUserDto>>.Success(userDtos);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while fetching users");
                return Response<List<AtsUserDto>>.Exception(ex);
            }
        }

        public async Task<Response<AtsUserDto>> GetUserAsync(Guid id)
        {
            try
            {
                var result = await _userRepository.GetAsync(id);
                var userDto = Mapper.Map<AtsUserDto>(result);
                return Response<AtsUserDto>.Success(userDto);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while fetching user with id.");
                return Response<AtsUserDto>.Exception(ex);
            }
        }

        public async Task<Response<AtsUserDto>> CreateUserAsync(AtsUserCreateDto user)
        {
            try
            {
                var createRef = Mapper.Map<User>(user);
                createRef.CreatedOn = DateTime.UtcNow;

                var result = await _userRepository.AddAsync(createRef);

                var userDto = Mapper.Map<AtsUserDto>(result);

                return Response<AtsUserDto>.Success(userDto);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while creating user.");
                return Response<AtsUserDto>.Exception(ex);
            }
        }

        public async Task<Response<AtsUserDto>> UpdateUserAsync(Guid id, AtsUserUpdateDto user)
        {
            try
            {
                var updateRef = await _userRepository.GetAsync(id);

                // Update fields
                updateRef.FirstName = user.FirstName;
                updateRef.LastName = user.LastName;
                updateRef.Password = user.Password;
                updateRef.UpdatedOn = DateTime.UtcNow;

                // Save changes
                var result = await _userRepository.UpdateAsync(updateRef);

                var userDto = Mapper.Map<AtsUserDto>(result);
                return Response<AtsUserDto>.Success(userDto);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while updating user.");
                return Response<AtsUserDto>.Exception(ex);
            }
        }


        public async Task<Response<AtsUserDto>> DeleteUserAsync(Guid id)
        {
            try
            {
                var deleteRef = await _userRepository.GetAsync(id);

                var result = await _userRepository.DeleteAsync(deleteRef);

                var userDto = Mapper.Map<AtsUserDto>(result);

                return Response<AtsUserDto>.Success(userDto);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while deleting user.");
                return Response<AtsUserDto>.Exception(ex);
            }
        }

        public async Task<Response<AtsUserDto>> GetUserWithJobCandidateAsync(string email)
        {
            try
            {
                var result = await _userRepository.GetUserWithJobCandidateAsync(email);
                var userDto = Mapper.Map<AtsUserDto>(result);

                return Response<AtsUserDto>.Success(userDto);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while fetching user with job candidate by email.");
                return Response<AtsUserDto>.Exception(ex);
            }
        }

    }
}
