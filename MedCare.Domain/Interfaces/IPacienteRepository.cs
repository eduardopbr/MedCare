using MedCare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.Domain.Interfaces
{
    public interface IPacienteRepository : IRepository<Paciente>
    {
        Task<List<Paciente>> GetPacientesByNome(string nome);
    }
}
