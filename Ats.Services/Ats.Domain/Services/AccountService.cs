
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

using Ats.Core.Abstraction;
using Ats.Core.Authentication;
using Ats.Core.Config;
using Ats.Core.Filtering;
using Ats.Datalayer.Entities;
using Ats.Datalayer.Interface;
using Ats.Domain.Services.Interface;
using Ats.Shared;
using Ats.Shared.Enums;

using AutoMapper;

using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Ats.Domain.Services
{
    public class AccountService : EntityService, IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserContext _userContext;
        private readonly IMicroServiceConfig _microServiceConfig;

        public AccountService(
            IMapper mapper,
            ILogger<AccountService> logger,
            IUserContext userContext,
            IMicroServiceConfig microServiceConfig,

            IUserRepository userRepository)
            : base(mapper, logger)
        {
            _userRepository = userRepository;
            _userContext = userContext;
            _microServiceConfig = microServiceConfig;
        }

        public async Task<Response<AuthUserIdentityDto>> GetIdentityAsync()
        {
            try
            {
                // Validate if the user is authenticated and has a valid token
                var user = await _userRepository.GetByEmailAsync(_userContext.Email);
                if (user == null)
                {
                    return Response<AuthUserIdentityDto>.Error(HttpStatusCode.Unauthorized,
                        new ErrorDto(ErrorCode.NoRecordFound, "User not found."));
                }

                var response = new AuthUserIdentityDto
                {
                    UserId = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    IsAdmin = user.IsAdmin,
                    IsApplicant = user.IsApplicant
                };

                return Response<AuthUserIdentityDto>.Success(response);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while fetching identity.");
                return Response<AuthUserIdentityDto>.Exception(ex);
            }
        }

        public async Task<Response<AuthLoginDto>> LoginAsync(AuthLoginRequestDto loginRequest)
        {
            try
            {
                var user = await _userRepository.GetByUsernamePasswordAsync(loginRequest.Username, loginRequest.Password);
                if (user == null)
                {
                    return Response<AuthLoginDto>.Error(HttpStatusCode.Unauthorized,
                        new ErrorDto(ErrorCode.NoRecordFound, "Invalid username or password."));
                }

                var response = new AuthLoginDto
                {
                    Succeeded = true,
                };

                // Generate Token
                var generateToken = GenerateToken(user);
                response.Token = generateToken.ToString();
                return Response<AuthLoginDto>.Success(response);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while logging in.");
                return Response<AuthLoginDto>.Exception(ex);
            }
        }

        public async Task<Response<AuthIdentityResultDto>> LogoutAsync()
        {
            // In case of using Identity Server, we can revoke the user logged in

            return Response<AuthIdentityResultDto>.Success(new AuthIdentityResultDto { Succeeded = true });
        }

        public async Task<Response<AuthRegisterResponseDto>> RegisterAsync(AuthRegisterRequestDto registerRequest)
        {
            try
            {
                if (registerRequest == null)
                    return Response<AuthRegisterResponseDto>.Error(HttpStatusCode.BadRequest,
                        new ErrorDto(ErrorCode.ValidationError, "Invalid request."));

                if (string.IsNullOrWhiteSpace(registerRequest.FirstName) ||
                    string.IsNullOrWhiteSpace(registerRequest.LastName) ||
                    string.IsNullOrWhiteSpace(registerRequest.Email) ||
                    string.IsNullOrWhiteSpace(registerRequest.Username) ||
                    string.IsNullOrWhiteSpace(registerRequest.Password))
                    return Response<AuthRegisterResponseDto>.Error(HttpStatusCode.BadRequest,
                        new ErrorDto(ErrorCode.ValidationError, "Invalid request."));

                // Check if email is already used
                var existingUserByEmail = await _userRepository.GetByEmailAsync(registerRequest.Email);
                if (existingUserByEmail != null)
                {
                    return Response<AuthRegisterResponseDto>.Error(HttpStatusCode.BadRequest,
                        new ErrorDto(ErrorCode.DuplicateRecord, "Email already exists."));
                }

                // Check if username is already used
                var existingUserByUsername = await _userRepository.GetByUsernameAsync(registerRequest.Username);
                if (existingUserByUsername != null)
                {
                    return Response<AuthRegisterResponseDto>.Error(HttpStatusCode.BadRequest,
                        new ErrorDto(ErrorCode.DuplicateRecord, "Username already exists."));
                }

                var userRecord = new User
                {
                    FirstName = registerRequest.FirstName,
                    LastName = registerRequest.LastName,
                    Email = registerRequest.Email,
                    Username = registerRequest.Username,
                    Password = registerRequest.Password,
                    IsAdmin = false,
                    IsApplicant = true,
                    CreatedOn = DateTime.UtcNow,
                };

                var user = await _userRepository.AddAsync(userRecord);

                var response = new AuthRegisterResponseDto
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Username = user.Username,
                };

                return Response<AuthRegisterResponseDto>.Success(response);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while registering user.");
                return Response<AuthRegisterResponseDto>.Exception(ex);
            }
        }

        private object GenerateToken(User user)
        {
            // Generate JwtSecurityToken
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_microServiceConfig.JwtConfig!.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_microServiceConfig.JwtConfig!.ExpiryDays);

            var generatedToken = new JwtSecurityToken(
                issuer: _microServiceConfig.JwtConfig.Issuer,
                audience: _microServiceConfig.JwtConfig.Audience,
                claims: new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(AuthClaims.FullName, user.FullName),
                    new Claim(AuthClaims.Admin, user.IsAdmin.ToString()),
                    //new Claim(ClaimTypes.Role, user.Role.ToString())
                },
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(generatedToken);
        }
    }
}
