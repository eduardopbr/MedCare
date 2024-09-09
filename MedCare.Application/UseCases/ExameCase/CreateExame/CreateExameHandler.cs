using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Application.UseCases.ProcedimentoCase;
using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MediatR;

namespace MedCare.Application.UseCases.ExameCase.CreateExame
{
    public class CreateExameHandler : IRequestHandler<CreateExameRequest, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateExameHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> Handle(CreateExameRequest request, CancellationToken cancellationToken)
        {
            Exame exame = new(request.tipo, request.pacienteid, request.data, request.hora, request.resultado);
            try
            {
                _unitOfWork.ExameRepository.Add(exame);

                await _unitOfWork.Commit(cancellationToken);
                return new Response(_mapper.Map<ExameBaseResponse>(exame)).AddSucessoMensagem("Exame cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                return new Response(CodeStateResponse.Warning).AddError(ex.Message);
            }
        }
    }
}
