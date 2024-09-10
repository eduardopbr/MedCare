using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Application.UseCases.PacienteCase.GetAllPacientes;
using MedCare.Application.UseCases.PacienteCase;
using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MediatR;

namespace MedCare.Application.UseCases.ProcedimentoCase.GetAllProcedimentos;

public class GetAllProcedimentosHandler : IRequestHandler<GetAllProcedimentosRequest, Response>
{
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;

    public GetAllProcedimentosHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _uof = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Response> Handle(GetAllProcedimentosRequest request, CancellationToken cancellationToken)
    {
        try
        {
            List<Procedimento> procedimentos = await _uof.ProcedimentoRepository.GetAllProcedimentos();

            List<AllProcedimentosResponse> response = AllProcedimentosResponse.CreateResponse(procedimentos).ToList();

            return new Response(response);
        }
        catch (Exception ex)
        {
            return new Response(CodeStateResponse.Error).AddError(ex.Message);
        }
    }
}
