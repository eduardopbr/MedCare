using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MedCare.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MedCare.Persistence.Repositories;

public class ExameRepository : Repository<Exame>, IExameRepository
{
    public ExameRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Exame?> GetExame(int id)
    {
        return await _context.Set<Exame>().Include(p => p.paciente).Where(p => p.id.Equals(id)).FirstOrDefaultAsync();
    }
}
