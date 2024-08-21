using Ats.Core.Authentication;
using Ats.Shared.Extensions;

namespace Ats.Core.Database
{
    public class DbUserContext : IDbUserContext
    {
        public Guid UserId { get; set; }
        public string UserEmail { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsApplicant { get; set; }

        public DbUserContext()
        {
            // For deserialization
        }

        public DbUserContext(IUserContext userContext)
        {
            AssignUserContext(userContext);
        }

        public void AssignUserContext(IUserContext userContext)
        {
            if (userContext == null) { return; }

            UserId = userContext.UserId;
            UserEmail = userContext.Email;
            IsAdmin = userContext.IsAdmin;
            IsApplicant = userContext.IsApplicant;
        }
    }
}
