using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ats.Models.Entities.JobList
{
    public class AtsJobListFilterDto
    {
        public string? JobTitle { get; set; }
        public string? JobLocation { get; set; }
        public string? JobSetting { get; set; }
    }
}
