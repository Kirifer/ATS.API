namespace Ats.Models
{
    public class AtsUserUpdateDto
    {
        public required string Password { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsApplicant { get; set; }
    }
}