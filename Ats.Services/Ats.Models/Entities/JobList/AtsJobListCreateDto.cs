using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ats.Models.Entities.JobList
{
    public class AtsJobListCreateDto
    {
        public required string JobTitle { get; set; }
        public required string JobDescription { get; set; }
        public required string JobLocation { get; set; }
        public required string JobSetting { get; set; }
        public required DateTime JobPosted { get; set; }
    }
}
