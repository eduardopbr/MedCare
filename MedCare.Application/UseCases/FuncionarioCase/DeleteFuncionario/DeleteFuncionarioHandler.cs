using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Application.UseCases.PacienteCase;
using MedCare.Application.UseCases.PacienteCase.DeletePaciente;
using MedCare.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.Application.UseCases.FuncionarioCase.DeleteFuncionario
{
    public class DeleteFuncionarioHandler : IRequestHandler<DeleteFuncionarioRequest, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteFuncionarioHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> Handle(DeleteFuncionarioRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var funcionario = await _unitOfWork.FuncionarioRepository.GetById(request.id, cancellationToken);

                if (funcionario == null) return new Response().AddError("Funcionário não encontrado");

                _unitOfWork.FuncionarioRepository.Delete(funcionario);
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
