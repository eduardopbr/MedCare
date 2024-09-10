using MedCare.Domain.Entities;

namespace MedCare.Domain.Interfaces;

public interface IProcedimentoRepository : IRepository<Procedimento>
{
    Task<List<Procedimento>> GetAllProcedimentos();
    Task<Procedimento?> GetProcedimento(int id);
}
