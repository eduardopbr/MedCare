using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MediatR;

namespace MedCare.Application.UseCases.PacienteCase.UpdatePaciente
{
    public class UpdatePacienteHandler : IRequestHandler<UpdatePacienteRequest, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePacienteHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> Handle(UpdatePacienteRequest request, CancellationToken cancellationToken)
        {
            var paciente = _mapper.Map<Paciente>(request);

            _unitOfWork.PacienteRepository.Update(paciente);

            await _unitOfWork.Commit(cancellationToken);

            return new Response(_mapper.Map<UpdatePacienteResponse>(paciente));
        }
    }
}
