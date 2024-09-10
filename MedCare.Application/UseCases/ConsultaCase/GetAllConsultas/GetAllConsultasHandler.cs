using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Application.UseCases.ExameCase.GetAllExames;
using MedCare.Application.UseCases.ExameCase;
using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MediatR;

namespace MedCare.Application.UseCases.ConsultaCase.GetAllConsultas;

public class GetAllConsultasHandler : IRequestHandler<GetAllConsultasRequest, Response>
{
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;

    public GetAllConsultasHandler(IUnitOfWork uof, IMapper mapper)
    {
        _uof = uof;
        _mapper = mapper;
    }

    public async Task<Response> Handle(GetAllConsultasRequest request, CancellationToken cancellationToken)
    {
        try
        {
            List<Consulta> consultas = await _uof.ConsultaRepository.GetAllConsultas();

            List<AllConsultasResponse> response = AllConsultasResponse.CreateResponse(consultas).ToList();

            return new Response(response);
        }
        catch (Exception ex)
        {
            return new Response(CodeStateResponse.Error).AddError(ex.Message);
        }
    }
}