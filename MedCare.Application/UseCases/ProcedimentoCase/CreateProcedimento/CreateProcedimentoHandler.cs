using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MediatR;

namespace MedCare.Application.UseCases.ProcedimentoCase.CreateProcedimento
{
    public class CreateProcedimentoHandler : IRequestHandler<CreateProcedimentoRequest, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProcedimentoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> Handle(CreateProcedimentoRequest request, CancellationToken cancellationToken)
        {
            var procedimento = _mapper.Map<Procedimento>(request);

            try
            {
                _unitOfWork.ProcedimentoRepository.Add(procedimento);

                await _unitOfWork.Commit(cancellationToken);
                return new Response(_mapper.Map<ProcedimentoBaseResponse>(procedimento));
            }
            catch (Exception ex)
            {
                return new Response().AddError(ex.Message);
            }
        }
    }
}
