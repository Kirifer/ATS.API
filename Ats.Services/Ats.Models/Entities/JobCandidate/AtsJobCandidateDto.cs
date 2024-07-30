using Ats.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ats.Models.Entities.JobCandidate
{
    public class AtsJobCandidateDto : EntityBaseDto
    {
        public string? JobRoleID { get; set; }

        public string? JobName { get; set; }

        public string? CandidateName { get; set; }

        public string? CandidateCv { get; set; }

        public string? CandidateEmail { get; set; }

        public int? CandidateContact { get; set; }

        public string? SourceTool { get; set; }

        public string? AssignedHr { get; set; }

        public int? AskingSalary { get; set; }

        public string? SalaryNegotiable { get; set; }

        public int? MinSalary { get; set; }

        public int? MaxSalary { get; set; }

        public string? NoticeDuration { get; set; }

        public string? ApplicationStatus { get; set; }

        public int? FinalSalary { get; set; }

        public int? Allowance { get; set; }

        public string? Honorarium { get; set; }

        public string? JobOffer { get; set; }

        public string? CandidateContract { get; set; }

        public string? Remarks { get; set; }
    }
}
