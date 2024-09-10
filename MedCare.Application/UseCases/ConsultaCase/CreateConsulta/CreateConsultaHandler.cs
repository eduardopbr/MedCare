using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MediatR;

namespace MedCare.Application.UseCases.ConsultaCase.CreateConsulta;

public class CreateConsultaHandler : IRequestHandler<CreateConsultaRequest, Response>
{
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;

    public CreateConsultaHandler(IUnitOfWork uof, IMapper mapper)
    {
        _uof = uof;
        _mapper = mapper;
    }

    public async Task<Response> Handle(CreateConsultaRequest request, CancellationToken cancellationToken)
    {
        try
        {
            Funcionario? funcionario = await _uof.FuncionarioRepository.GetById(request.funcionarioid, cancellationToken);

            if (funcionario is null) return new Response(CodeStateResponse.Warning).AddError("Funcionário não encontrado");

            if (!funcionario.FuncionarioEhMedico())
                return new Response(CodeStateResponse.Warning).AddAvisoMensagem("O funcionário selecionado não é médico");

            Consulta consulta = new(request.pacienteid, request.datanascimento, request.funcionarioid,
            request.registro, request.especialidade, request.diagnostico, request.examesrelacionados);

            _uof.ConsultaRepository.Add(consulta);

            await _uof.Commit(cancellationToken);
            return new Response(_mapper.Map<ConsultaBaseResponse>(consulta)).AddSucessoMensagem("Consulta cadastrada com sucesso");
        }
        catch (Exception ex)
        {
            return new Response(CodeStateResponse.Error).AddError(ex.Message);
        }
    }
}
