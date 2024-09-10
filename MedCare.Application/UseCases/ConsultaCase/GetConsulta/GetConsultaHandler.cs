using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MediatR;

namespace MedCare.Application.UseCases.ConsultaCase.GetConsulta;

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
            Consulta? consulta = await _uof.ConsultaRepository.GetConsulta(request.id);

            if (consulta is null)
                return new Response(CodeStateResponse.Warning).AddError("Consulta não encontrada");

            ConsultaResponse response = ConsultaResponse.CreateResponse(consulta);

            return new Response(response);
        }
        catch (Exception ex)
        {
            return new Response(CodeStateResponse.Error).AddError(ex.Message);
        }
    }
}
