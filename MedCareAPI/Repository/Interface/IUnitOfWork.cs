using Microsoft.EntityFrameworkCore.Storage;

namespace MedCareAPI.Repository.Interface
{
    public interface IUnitOfWork
    {
        Task Commit();

        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
