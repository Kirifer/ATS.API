using Ats.Shared.Models;

namespace Ats.Models
{
    public class AtsUserDto : EntityBaseDto
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
