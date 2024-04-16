using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MediatR;

namespace MedCare.Application.UseCases.ExameCase.UpdateExame
{
    public class UpdateExameHandler : IRequestHandler<UpdateExameRequest, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateExameHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> Handle(UpdateExameRequest request, CancellationToken cancellationToken)
        {
            var exame = _mapper.Map<Exame>(request);

            _unitOfWork.ExameRepository.Update(exame);

            await _unitOfWork.Commit(cancellationToken);

            return new Response(_mapper.Map<ExameBaseResponse>(exame));
        }
    }
}
