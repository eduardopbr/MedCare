using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MedCare.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.Persistence.Repositories
{
    public class PacienteRepository : Repository<Paciente>, IPacienteRepository
    {
        public PacienteRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<List<Paciente>> GetPacientesByNome(string nome)
        {
            return await _context.Set<Paciente>().Where(p => p.nome.Contains(nome)).ToListAsync();
        }
    }
}
