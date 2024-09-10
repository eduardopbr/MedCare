using MedCare.Domain.Entities;

namespace MedCare.Application.UseCases.ConsultaCase.GetConsulta;

public sealed record ConsultaResponse
{
    public ConsultaResponse(int consulta_id, int pacienteid, string paciente_nome, DateTime datanasc, int funcionarioid, string funcionario_nome, int registro, 
        string especialidade, string diagnostico, string? examesrelacionados)
    {
        this.consulta_id = consulta_id;
        this.pacienteid = pacienteid;
        this.paciente_nome = paciente_nome;
        this.datanasc = datanasc;
        this.funcionarioid = funcionarioid;
        this.funcionario_nome = funcionario_nome;
        this.registro = registro;
        this.especialidade = especialidade;
        this.diagnostico = diagnostico;
        this.examesrelacionados = examesrelacionados;
    }

    public int consulta_id { get; set; }
    public int pacienteid { get; set; }
    public string paciente_nome { get; set; } = null!;
    public DateTime datanasc { get; set; }
    public int funcionarioid { get; set; }
    public string funcionario_nome { get; set; } = null!;
    public int registro { get; set; }
    public string especialidade { get; set; } = null!;

    public string diagnostico { get; set; } = null!;

    public string? examesrelacionados { get; set; }

    public static ConsultaResponse CreateResponse(Consulta consulta)
    {
        return new(
            consulta.id,
            consulta.pacienteid,
            consulta.paciente.nome,
            consulta.datanasc,
            consulta.funcionarioid,
            consulta.funcionario.nome,
            consulta.registro,
            consulta.especialidade,
            consulta.diagnostico,
            consulta.examesrelacionados
        );
    }
}
