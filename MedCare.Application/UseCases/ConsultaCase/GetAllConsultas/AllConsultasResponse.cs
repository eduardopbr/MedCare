using MedCare.Domain.Entities;

namespace MedCare.Application.UseCases.ConsultaCase.GetAllConsultas;

public sealed record AllConsultasResponse
{
    public AllConsultasResponse(int consulta_id, int pacienteid, string paciente_nome, int funcionarioid, string funcionario_nome, DateTime datanasc, int registro, 
        string especialidade, string diagnostico, string? examesrelacionados)
    {
        this.consulta_id = consulta_id;
        this.pacienteid = pacienteid;
        this.paciente_nome = paciente_nome;
        this.funcionarioid = funcionarioid;
        this.funcionario_nome = funcionario_nome;
        this.datanasc = datanasc;
        this.registro = registro;
        this.especialidade = especialidade;
        this.diagnostico = diagnostico;
        this.examesrelacionados = examesrelacionados;
    }

    public int consulta_id { get; set; }
    public int pacienteid { get; set; }
    public string paciente_nome { get; set; } = null!;
    public int funcionarioid { get; set; }
    public string funcionario_nome { get; set; } = null!;
    public DateTime datanasc { get; set; }
    public int registro { get; set; }
    public string especialidade { get; set; } = null!;

    public string diagnostico { get; set; } = null!;

    public string? examesrelacionados { get; set; }

    public static IEnumerable<AllConsultasResponse> CreateResponse(List<Consulta> consultas)
    {
        foreach (var item in consultas)
        {
            AllConsultasResponse response = new(
                item.id,
                item.pacienteid,
                item.paciente.nome,
                item.funcionarioid,
                item.funcionario.nome,
                item.datanasc,
                item.registro,
                item.especialidade,
                item.diagnostico,
                item.examesrelacionados
            );

            yield return response;
        }
    }
}
