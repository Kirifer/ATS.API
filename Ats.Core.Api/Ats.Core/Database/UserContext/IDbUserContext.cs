using Ats.Core.Authentication;

namespace Ats.Core.Database
{
    public interface IDbUserContext
    {
        public Guid UserId { get; set; }

        public string UserEmail { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsApplicant { get; set; }

        public void AssignUserContext(IUserContext userContext);
    }
}
