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

    public GetAllConsultasHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _uof = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Response> Handle(GetAllConsultasRequest request, CancellationToken cancellationToken)
    {
        try
        {
            List<Consulta> consultas = await _uof.ConsultaRepository.GetAll(cancellationToken);

            return new Response(_mapper.Map<List<ConsultaBaseResponse>>(consultas));
        }
        catch (Exception ex)
        {
            return new Response(CodeStateResponse.Error).AddError(ex.Message);
        }
    }
}