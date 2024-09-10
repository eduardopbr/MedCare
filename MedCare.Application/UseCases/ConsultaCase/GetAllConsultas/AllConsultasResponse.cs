using MedCare.Domain.Entities;

namespace MedCare.Application.UseCases.ConsultaCase.GetAllConsultas;

public sealed record AllConsultasResponse
{
    public AllConsultasResponse(int consulta_id, int pacienteid, string paciente_nome, int funcionarioid, string funcionario_nome)
    {
        this.consulta_id = consulta_id;
        this.pacienteid = pacienteid;
        this.paciente_nome = paciente_nome;
        this.funcionarioid = funcionarioid;
        this.funcionario_nome = funcionario_nome;
    }

    public int consulta_id { get; set; }
    public int pacienteid { get; set; }
    public string paciente_nome { get; set; } = null!;
    public int funcionarioid { get; set; }
    public string funcionario_nome { get; set; } = null!;

    public static IEnumerable<AllConsultasResponse> CreateResponse(List<Consulta> consultas)
    {
        foreach (var item in consultas)
        {
            AllConsultasResponse response = new(
                item.id,
                item.pacienteid,
                item.paciente.nome,
                item.funcionarioid,
                item.funcionario.nome
            );

            yield return response;
        }
    }
}
