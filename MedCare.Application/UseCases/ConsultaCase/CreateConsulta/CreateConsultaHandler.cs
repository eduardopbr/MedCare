using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MediatR;

namespace MedCare.Application.UseCases.ConsultaCase.CreateConsulta
{
    public class CreateConsultaHandler : IRequestHandler<CreateConsultaRequest, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateConsultaHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> Handle(CreateConsultaRequest request, CancellationToken cancellationToken)
        {
            var consulta = _mapper.Map<Consulta>(request);

            try
            {
                _unitOfWork.ConsultaRepository.Add(consulta);

                await _unitOfWork.Commit(cancellationToken);
                return new Response(_mapper.Map<ConsultaBaseResponse>(consulta));
            }
            catch (Exception ex)
            {
                return new Response(CodeStateResponse.Error).AddError(ex.Message);
            }
        }
    }
}
