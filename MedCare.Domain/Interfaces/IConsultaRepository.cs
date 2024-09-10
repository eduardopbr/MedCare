using MedCare.Domain.Entities;

namespace MedCare.Domain.Interfaces
{
    public interface IConsultaRepository : IRepository<Consulta>
    {
        Task<List<Consulta>> GetAllConsultas();
        Task<Consulta?> GetConsulta(int id);
    }
}
