using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Application.UseCases.PacienteCase.UpdatePaciente;
using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.Application.UseCases.FuncionarioCase.UpdateFuncionario
{
    public class UpdateFuncionarioHandler : IRequestHandler<UpdateFuncionarioRequest, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateFuncionarioHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> Handle(UpdateFuncionarioRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var funcionario = _mapper.Map<Funcionario>(request);

                _unitOfWork.FuncionarioRepository.Update(funcionario);

                await _unitOfWork.Commit(cancellationToken);

                return new Response(_mapper.Map<FuncionarioBaseResponse>(funcionario));
            }
            catch (Exception ex)
            {
                return new Response().AddError(ex.Message);
            }
        }
    }
}
