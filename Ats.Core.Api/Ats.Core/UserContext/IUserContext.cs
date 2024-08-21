namespace Ats.Core.Authentication
{
    public interface IUserContext
    {
        Guid UserId { get; set; }

        string FullName { get; set; }

        string Email { get; set; }

        bool IsAdmin { get; set; }

        bool IsApplicant { get; set; }
    }
}
