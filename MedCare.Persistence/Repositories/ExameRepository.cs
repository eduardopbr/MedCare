using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MedCare.Persistence.Context;

namespace MedCare.Persistence.Repositories
{
    public class ExameRepository : Repository<Exame>, IExameRepository
    {
        public ExameRepository(AppDbContext context) : base(context)
        {
        }
    }
}
