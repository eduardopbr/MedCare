using MedCareAPI.Repository.Interface;
using MedCareLib.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace MedCareAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }
    }
}
