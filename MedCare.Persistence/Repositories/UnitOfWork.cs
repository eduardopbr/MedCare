using MedCare.Domain.Interfaces;
using MedCare.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace MedCare.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private PacienteRepository _pacienteRepo;
        private FuncionarioRepository _funcionarioRepo;
        public AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IDbTransaction> BeginTransaction()
        {
            return (await _context.Database.BeginTransactionAsync()).GetDbTransaction();
        }

        public async Task Commit(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public IPacienteRepository PacienteRepository
        {
            get
            {
                return _pacienteRepo = _pacienteRepo ?? new PacienteRepository(_context);
            }
        }

        public IFuncionarioRepository FuncionarioRepository
        {
            get
            {
                return _funcionarioRepo = _funcionarioRepo ?? new FuncionarioRepository(_context);
            }
        }
    }
}
