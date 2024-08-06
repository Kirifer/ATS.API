namespace Ats.Models.Entities.JobCandidate
{
    public class AtsJobCandidateAttachmentUploadDto
    {
        public Guid? Id { get; set; }

        public string FileName { get; set; } // File Name

        public string Content { get; set; } // Base64 Encoded string

        public bool HasContent => !string.IsNullOrEmpty(Content);
        public bool IsExisting => Id.HasValue;
    }
}
