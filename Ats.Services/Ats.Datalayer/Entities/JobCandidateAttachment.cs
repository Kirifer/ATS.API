using Ats.Core.Database.Abstraction;

namespace Ats.Datalayer.Entities
{
    public class JobCandidateAttachment : DbEntityIdBase
    {
        public Guid Id { get; set; }

        public Guid JobCandidateId { get; set; }

        public string FileName { get; set; }

        public string FilePath { get; set; }

        public long Size { get; set; }

        public string Extension { get; set; }

        public string SavedFileName { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
    }
}
