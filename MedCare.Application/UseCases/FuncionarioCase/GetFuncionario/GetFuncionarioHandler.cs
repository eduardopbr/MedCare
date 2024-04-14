using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Application.UseCases.PacienteCase;
using MedCare.Application.UseCases.PacienteCase.GetPaciente;
using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.Application.UseCases.FuncionarioCase.GetFuncionario
{
    public class GetFuncionarioHandler : IRequestHandler<GetFuncionarioRequest, Response>
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public GetFuncionarioHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uof = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> Handle(GetFuncionarioRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Funcionario? funcionario = await _uof.FuncionarioRepository.GetById(request.funcionarioid, cancellationToken);

                if (funcionario is null)
                    return new Response().AddError("Funcionário não encontrado");

                return new Response(_mapper.Map<PacienteBaseResponse>(funcionario));
            }
            catch (Exception ex)
            {
                return new Response().AddError(ex.Message);
            }
        }
    }
}
