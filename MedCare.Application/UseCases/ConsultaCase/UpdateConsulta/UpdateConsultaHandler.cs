using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MediatR;

namespace MedCare.Application.UseCases.ConsultaCase.UpdateConsulta
{
    public class UpdateConsultaHandler : IRequestHandler<UpdateConsultaRequest, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateConsultaHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> Handle(UpdateConsultaRequest request, CancellationToken cancellationToken)
        {
            Consulta? consulta = await _unitOfWork.ConsultaRepository.GetById(request.id, cancellationToken);

            if (consulta is null) return new Response(CodeStateResponse.Warning).AddError("Consulta não localizada");

            consulta.Atualizar(request.pacienteid, request.datanascimento, request.funcionarioid, request.registro, request.especialidade, request.diagnostico, request.examesrelacionados);

            _unitOfWork.ConsultaRepository.Update(consulta);

            await _unitOfWork.Commit(cancellationToken);

            return new Response(_mapper.Map<ConsultaBaseResponse>(consulta));
        }
    }
}
