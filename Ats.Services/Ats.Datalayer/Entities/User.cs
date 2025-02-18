﻿using Ats.Core.Database.Abstraction;

namespace Ats.Datalayer.Entities
{
    public class User : DbEntityFullBase
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsApplicant { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public virtual ICollection<JobCandidate> JobCandidates { get; set; } = new List<JobCandidate>();
    }
}
    