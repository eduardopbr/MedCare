using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MedCare.Persistence.Context;

namespace MedCare.Persistence.Repositories
{
    public class ConsultaRepository : Repository<Consulta>, IConsultaRepository
    {
        public ConsultaRepository(AppDbContext context) : base(context)
        {
        }
    }
}
