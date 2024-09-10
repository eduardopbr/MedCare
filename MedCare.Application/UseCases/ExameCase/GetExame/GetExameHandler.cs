using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MediatR;

namespace MedCare.Application.UseCases.ExameCase.GetExame;

public class GetExameHandler : IRequestHandler<GetExameRequest, Response>
{
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;

    public GetExameHandler(IUnitOfWork uof, IMapper mapper)
    {
        _uof = uof;
        _mapper = mapper;
    }

    public async Task<Response> Handle(GetExameRequest request, CancellationToken cancellationToken)
    {
        try
        {
            Exame? exame = await _uof.ExameRepository.GetExame(request.id);

            if (exame is null)
                return new Response(CodeStateResponse.Warning).AddError("Exame não encontrado");

            ExameResponse response = ExameResponse.CreateResponse(exame);

            return new Response(response);
        }
        catch (Exception ex)
        {
            return new Response(CodeStateResponse.Error).AddError(ex.Message);
        }
    }
}
