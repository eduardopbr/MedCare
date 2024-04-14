using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IPacienteRepository PacienteRepository { get; }
        IFuncionarioRepository FuncionarioRepository { get; }
        Task Commit(CancellationToken cancellationToken);
        Task<IDbTransaction> BeginTransaction();
    }
}
