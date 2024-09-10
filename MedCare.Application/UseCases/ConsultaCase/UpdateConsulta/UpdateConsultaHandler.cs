using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MediatR;

namespace MedCare.Application.UseCases.ConsultaCase.UpdateConsulta
{
    public class UpdateConsultaHandler : IRequestHandler<UpdateConsultaRequest, Response>
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public UpdateConsultaHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uof = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> Handle(UpdateConsultaRequest request, CancellationToken cancellationToken)
        {
            Funcionario? funcionario = await _uof.FuncionarioRepository.GetById(request.funcionarioid, cancellationToken);

            if (funcionario is null) return new Response(CodeStateResponse.Warning).AddError("Funcionário não encontrado");

            if (!funcionario.FuncionarioEhMedico())
                return new Response(CodeStateResponse.Warning).AddError("O funcionário selecionado não é médico");

            Consulta? consulta = await _uof.ConsultaRepository.GetById(request.id, cancellationToken);

            if (consulta is null) return new Response(CodeStateResponse.Warning).AddError("Consulta não localizada");

            consulta.Atualizar(request.pacienteid, request.datanascimento, request.funcionarioid, request.registro, request.especialidade, request.diagnostico, request.examesrelacionados);

            _uof.ConsultaRepository.Update(consulta);

            await _uof.Commit(cancellationToken);

            return new Response(_mapper.Map<ConsultaBaseResponse>(consulta));
        }
    }
}
