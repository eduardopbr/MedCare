using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MediatR;

namespace MedCare.Application.UseCases.ConsultaCase.GetConsulta
{
    public class GetConsultaHandler : IRequestHandler<GetConsultaRequest, Response>
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public GetConsultaHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uof = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> Handle(GetConsultaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Consulta? consulta = await _uof.ConsultaRepository.GetById(request.id, cancellationToken);

                if (consulta is null)
                    return new Response().AddError("Consulta não encontrada");

                return new Response(_mapper.Map<ConsultaBaseResponse>(consulta));
            }
            catch (Exception ex)
            {
                return new Response().AddError(ex.Message);
            }
        }
    }
}
