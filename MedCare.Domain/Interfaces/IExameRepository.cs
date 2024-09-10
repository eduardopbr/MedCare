using MedCare.Domain.Entities;

namespace MedCare.Domain.Interfaces
{
    public interface IExameRepository : IRepository<Exame>
    {
        Task<Exame?> GetExame(int id);
    }
}
