using Ats.Datalayer.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ats.DataLayer.Configurations
{
    public class JobCandidateConfiguration : IEntityTypeConfiguration<JobCandidate>
    {
        public void Configure(EntityTypeBuilder<JobCandidate> builder)
        {
            builder
                .HasOne(jc => jc.JobRole)
                .WithMany(jr => jr.Candidates)
                .HasForeignKey(jc => jc.JobRoleId)
                .HasPrincipalKey(jr => jr.SequenceNo)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(jc => jc.User)
                .WithMany(u => u.JobCandidates) // Assuming one user can have multiple job application
                .HasForeignKey(jc => jc.CandidateEmail)
                .HasPrincipalKey(u => u.Email)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
