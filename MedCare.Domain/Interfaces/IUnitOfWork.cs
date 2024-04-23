using System.Data;

namespace MedCare.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IPacienteRepository PacienteRepository { get; }
        IFuncionarioRepository FuncionarioRepository { get; }
        IProcedimentoRepository ProcedimentoRepository { get; }
        IExameRepository ExameRepository { get; }
        IConsultaRepository ConsultaRepository { get; }
        Task Commit(CancellationToken cancellationToken);
        Task<IDbTransaction> BeginTransaction();
    }
}
