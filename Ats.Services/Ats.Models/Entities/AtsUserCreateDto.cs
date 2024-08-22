namespace Ats.Models
{
    public class AtsUserCreateDto
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsApplicant { get; set; }
    }
}