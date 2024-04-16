using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MediatR;

namespace MedCare.Application.UseCases.ProcedimentoCase.UpdateProcedimento
{
    public class UpdateProcedimentoHandler : IRequestHandler<UpdateProcedimentoRequest, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProcedimentoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> Handle(UpdateProcedimentoRequest request, CancellationToken cancellationToken)
        {
            var procedimento = _mapper.Map<Procedimento>(request);

            _unitOfWork.ProcedimentoRepository.Update(procedimento);

            await _unitOfWork.Commit(cancellationToken);

            return new Response(_mapper.Map<ProcedimentoBaseResponse>(procedimento));
        }
    }
}
