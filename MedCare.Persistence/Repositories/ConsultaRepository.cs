using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MedCare.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MedCare.Persistence.Repositories;

public class ConsultaRepository : Repository<Consulta>, IConsultaRepository
{
    public ConsultaRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<Consulta>> GetAllConsultas()
    {
        return await _context.Set<Consulta>().Include(p => p.paciente).Include(p => p.funcionario).ToListAsync();
    }

    public async Task<Consulta?> GetConsulta(int id)
    {
        return await _context.Set<Consulta>().Include(p => p.paciente).Include(p => p.funcionario).Where(p => p.id.Equals(id)).FirstOrDefaultAsync();
    }
}
