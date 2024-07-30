using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ats.Models.Entities.JobCandidate
{
    public class AtsJobCandidateUpdateDto
    {
        public required string CandidateName { get; set; }

        public required string CandidateCv { get; set; }

        public required string CandidateEmail { get; set; }

        public required int CandidateContact { get; set; }

        public required string SourceTool { get; set; }

        public required string AssignedHr { get; set; }

        public required int AskingSalary { get; set; }

        public required string SalaryNegotiable { get; set; }

        public required int MinSalary { get; set; }

        public required int MaxSalary { get; set; }

        public required string NoticeDuration { get; set; }

        public required string ApplicationStatus { get; set; }

        public required int FinalSalary { get; set; }

        public required int Allowance { get; set; }

        public required string Honorarium { get; set; }

        public required string JobOffer { get; set; }

        public required string CandidateContract { get; set; }

        public required string Remarks { get; set; }
    }
}
