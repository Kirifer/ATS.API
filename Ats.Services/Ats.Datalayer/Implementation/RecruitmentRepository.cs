using Ats.Datalayer.Entities;
using Ats.Datalayer.Interface;

namespace Ats.Datalayer.Implementation
{
    public class RecruitmentRepository : BaseRepository<Recruitment>, IRecruitmentRepository
    {
        public RecruitmentRepository(AtsDbContext context) : base(context)
        {

        }
    }
}
