using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MedCare.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.Persistence.Repositories
{
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(AppDbContext context) : base(context)
        {
        }
    }
}
