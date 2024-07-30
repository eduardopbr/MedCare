using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Domain.Interfaces;
using MediatR;

namespace MedCare.Application.UseCases.ExameCase.DeleteExame
{
    public class DeleteExameHandler : IRequestHandler<DeleteExameRequest, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteExameHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> Handle(DeleteExameRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var exame = await _unitOfWork.ExameRepository.GetById(request.id, cancellationToken);

                if (exame == null) return new Response(CodeStateResponse.Warning).AddError("Exame não encontrado");

                _unitOfWork.ExameRepository.Delete(exame);
                await _unitOfWork.Commit(cancellationToken);

                return new Response(CodeStateResponse.Success);
            }
            catch (Exception ex)
            {
                return new Response(CodeStateResponse.Warning).AddError(ex.Message);
            }
        }
    }
}
