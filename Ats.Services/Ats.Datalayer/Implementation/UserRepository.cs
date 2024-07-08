using Ats.Datalayer.Entities;
using Ats.Datalayer.Interface;

namespace Ats.Datalayer.Implementation
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AtsDbContext context) : base(context)
        {

        }
    }
}
