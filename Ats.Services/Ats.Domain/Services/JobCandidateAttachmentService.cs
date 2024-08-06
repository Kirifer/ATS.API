using Ats.Core.Abstraction;
using Ats.Core.Filtering;
using Ats.Datalayer.Entities;
using Ats.Datalayer.Interface;
using Ats.Domain.Services.Interface;
using Ats.Models.Entities.JobCandidate;
using Ats.Shared.Models;

using AutoMapper;

using Microsoft.Extensions.Logging;

namespace Ats.Domain.Services
{
    public class JobCandidateAttachmentService : EntityService, IJobCandidateAttachmentService
    {
        private readonly IJobCandidateAttachmentRepository _jobCandidateAttachmentRepository;

        public JobCandidateAttachmentService(
            IMapper mapper,
            ILogger<JobCandidateAttachmentService> logger,
            IJobCandidateAttachmentRepository jobCandidateAttachmentRepository)
            : base (mapper, logger)
        {
            _jobCandidateAttachmentRepository = jobCandidateAttachmentRepository;
        }

        public async Task<Response<List<AtsJobCandidateAttachmentDto>>> GetJobCandidateAttachmentsAsync(Guid jobCandidateId)
        {
            try
            {
                // Get Data on repository
                var result = await _jobCandidateAttachmentRepository.GetAllAsync(attachment => attachment.JobCandidateId == jobCandidateId);

                if (result != null && result.Count != 0)
                {
                    var attachments = new List<AtsJobCandidateAttachmentDto>();

                    foreach (var attachment in result)
                    {
                        // Get the content saved locally
                        var fileResult = await File.ReadAllBytesAsync(attachment.FilePath);

                        using (var memoryStream = new MemoryStream(fileResult))
                        {
                            // Convert the file to base64 string
                            var base64String = Convert.ToBase64String(memoryStream.ToArray());

                            // Map the result to DTO
                            var attachmentDto = Mapper.Map<AtsJobCandidateAttachmentDto>(attachment);

                            // Set the content to the DTO
                            attachmentDto.Content = base64String;

                            attachments.Add(attachmentDto);
                        }
                    }

                    // Return the list of DTO
                    return Response<List<AtsJobCandidateAttachmentDto>>.Success(attachments);
                }

                // Return empty list if no data found
                return Response<List<AtsJobCandidateAttachmentDto>>.Success(new List<AtsJobCandidateAttachmentDto>());
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while fetching the attachment data.");
                return Response<List<AtsJobCandidateAttachmentDto>>.Exception(ex);
            }
        }

        public async Task<Response<AtsJobCandidateAttachmentDto>> GetJobCandidateAttachmentAsync(Guid id)
        {
            try
            {
                // Get Data on repository
                var result = await _jobCandidateAttachmentRepository.GetAsync(id);
                if (result == null)
                {
                    return Response<AtsJobCandidateAttachmentDto>.Error(
                        System.Net.HttpStatusCode.NotFound,
                        Shared.Enums.ErrorCode.NoRecordFound,
                        "Could not find attachment record.");
                }

                // Get the content saved locally
                var fileResult = await File.ReadAllBytesAsync(result.FilePath);

                using (var memoryStream = new MemoryStream(fileResult))
                {
                    // Convert the file to base64 string
                    var base64String = Convert.ToBase64String(memoryStream.ToArray());

                    // Map the result to DTO
                    var attachmentDto = Mapper.Map<AtsJobCandidateAttachmentDto>(result);

                    // Set the content to the DTO
                    attachmentDto.Content = base64String;

                    return Response<AtsJobCandidateAttachmentDto>.Success(attachmentDto);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while fetching the attachment data.");
                return Response<AtsJobCandidateAttachmentDto>.Exception(ex);
            }
        }

        public async Task<Response<AtsJobCandidateAttachmentDto>> UploadJobCandidateAttachmentAsync(Guid jobCandidateId, AtsJobCandidateAttachmentUploadDto uploadPayload)
        {
            try
            {
                var generateFileName = $"{Guid.NewGuid()}{Path.GetExtension(uploadPayload.FileName)}";
                var filePath = Path.Combine(Environment.CurrentDirectory, "Uploads", generateFileName);

                // Create the directory if not exists
                if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                }

                // Upload file locally
                await File.WriteAllBytesAsync(filePath, Convert.FromBase64String(uploadPayload.Content));

                // Map the DTO to Entity
                var attachment = Mapper.Map<JobCandidateAttachment>(uploadPayload);

                attachment.FileName = uploadPayload.FileName;
                attachment.JobCandidateId = jobCandidateId;
                attachment.FilePath = filePath;
                attachment.Size = uploadPayload.Content.Length;
                attachment.Extension = Path.GetExtension(uploadPayload.FileName);
                attachment.SavedFileName = generateFileName;
                attachment.CreatedOn = DateTime.UtcNow;

                var result = await _jobCandidateAttachmentRepository.AddAsync(attachment);

                var attachmentDto = Mapper.Map<AtsJobCandidateAttachmentDto>(result);
                attachmentDto.Content = uploadPayload.Content;

                return Response<AtsJobCandidateAttachmentDto>.Success(attachmentDto);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while uploading the attachment.");
                return Response<AtsJobCandidateAttachmentDto>.Exception(ex);
            }
        }

        public async Task<Response<EntityBaseDto>> DeleteJobCandidateAttachmentAsync(Guid id)
        {
            try
            {
                var deleteRef = await _jobCandidateAttachmentRepository.GetAsync(id);

                // Delete the file saved locally
                File.Delete(deleteRef.FilePath);

                var result = await _jobCandidateAttachmentRepository.DeleteAsync(deleteRef);

                return Response<EntityBaseDto>.Success(new EntityFullBaseDto { Id = id});

            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while deleting the attachment.");
                return Response<EntityBaseDto>.Exception(ex);
            }
        }
    }
}
