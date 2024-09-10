using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MedCare.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MedCare.Persistence.Repositories;

public class ProcedimentoRepository : Repository<Procedimento>, IProcedimentoRepository
{
    public ProcedimentoRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Procedimento?> GetProcedimento(int id)
    {
        return await _context.Set<Procedimento>().Include(p => p.funcionario).Include(p => p.paciente).Where(p => p.id == id).FirstOrDefaultAsync();
    }

    public async Task<List<Procedimento>> GetAllProcedimentos()
    {
        return await _context.Set<Procedimento>().Include(p => p.paciente).Include(p => p.funcionario).ToListAsync();
    }
}
