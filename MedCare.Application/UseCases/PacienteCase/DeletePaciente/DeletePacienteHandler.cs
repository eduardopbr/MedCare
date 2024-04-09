using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Application.UseCases.PacienteCase.CreatePaciente;
using MedCare.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.Application.UseCases.PacienteCase.DeletePaciente
{
    public class DeletePacienteHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeletePacienteHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> Handle(DeletePacienteRequest request, CancellationToken cancellationToken)
        {

            var paciente = await _unitOfWork.PacienteRepository.GetById(request.id, cancellationToken);

            if (paciente == null) return new Response().AddError("Paciente não encontrado");

            _unitOfWork.PacienteRepository.Delete(paciente);
            await _unitOfWork.Commit(cancellationToken);

            return new Response(_mapper.Map<DeletePacienteResponse>(paciente));
        }
    }
}
