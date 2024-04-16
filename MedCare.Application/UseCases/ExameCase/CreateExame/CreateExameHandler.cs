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
            var exame = _mapper.Map<Exame>(request);

            try
            {
                _unitOfWork.ExameRepository.Add(exame);

                await _unitOfWork.Commit(cancellationToken);
                return new Response(_mapper.Map<ExameBaseResponse>(exame));
            }
            catch (Exception ex)
            {
                return new Response().AddError(ex.Message);
            }
        }
    }
}
