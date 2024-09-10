using MedCare.Domain.Entities;

namespace MedCare.Domain.Interfaces;

public interface IProcedimentoRepository : IRepository<Procedimento>
{
    Task<Procedimento?> GetProcedimento(int id);
}
