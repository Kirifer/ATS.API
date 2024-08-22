namespace Ats.Shared
{
    public class AuthRegisterResponseDto
    {
        public string? FullName => $"{FirstName} {LastName}";

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Username { get; set; }
    }
}
