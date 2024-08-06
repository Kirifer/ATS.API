using Ats.Shared.Models;

namespace Ats.Models.Entities.JobCandidate
{
    public class AtsJobCandidateAttachmentDto : EntityBaseDto
    {
        public string FileName { get; set; } // File Name

        public string Path { get; set; } // File Path

        public int Size { get; set; } // File Size

        public string Extension { get; set; } // File Extension

        public string SavedFiledName { get; set; } // Saved File Name

        public DateTimeOffset CreatedOn { get; set; }

        public string Content { get; set; } // Base64 Encoded string
    }
}
