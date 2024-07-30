using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MediatR;

namespace MedCare.Application.UseCases.ExameCase.UpdateExame;

public class UpdateExameHandler : IRequestHandler<UpdateExameRequest, Response>
{
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;

    public UpdateExameHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _uof = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Response> Handle(UpdateExameRequest request, CancellationToken cancellationToken)
    {
        var exame = await _uof.ExameRepository.GetById(request.id, cancellationToken);

        if (exame is null)
            return new Response(CodeStateResponse.Warning).AddError("Exame não localizado");

        exame.Atualizar(request.tipo, request.pacienteid, request.data, request.hora, request.resultado);

        _uof.ExameRepository.Update(exame);

        await _uof.Commit(cancellationToken);

        return new Response(_mapper.Map<ExameBaseResponse>(exame));
    }
}
