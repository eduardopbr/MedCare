using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Application.UseCases.PacienteCase.DeletePaciente;
using MedCare.Application.UseCases.PacienteCase;
using MedCare.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MedCare.Application.UseCases.ProcedimentoCase.DeleteProcedimento
{
    public class DeleteProcedimentoHandler : IRequestHandler<DeleteProcedimentoRequest, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteProcedimentoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> Handle(DeleteProcedimentoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var paciente = await _unitOfWork.PacienteRepository.GetById(request.id, cancellationToken);

                if (paciente == null) return new Response().AddError("Procedimento não encontrado");

                _unitOfWork.PacienteRepository.Delete(paciente);
                await _unitOfWork.Commit(cancellationToken);

                return new Response();
            }
            catch (Exception ex)
            {
                return new Response().AddError(ex.Message);
            }
        }
    }
}
