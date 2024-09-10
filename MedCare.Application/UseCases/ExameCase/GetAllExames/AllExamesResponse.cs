using MedCare.Domain.Entities;

namespace MedCare.Application.UseCases.ExameCase.GetAllExames;

public sealed record AllExamesResponse
{
    public AllExamesResponse(int exame_id, string tipo, int pacienteid, string paciente_nome, DateTime data, TimeSpan hora, string? resultado)
    {
        this.exame_id = exame_id;
        this.tipo = tipo;
        this.pacienteid = pacienteid;
        this.paciente_nome = paciente_nome;
        this.data = data;
        this.hora = hora;
        this.resultado = resultado;
    }

    public int exame_id { get; set; }
    public string tipo { get; set; } = null!;
    public int pacienteid { get; set; }
    public string paciente_nome { get; set; } = null!;
    public DateTime data { get; set; }
    public TimeSpan hora { get; set; }
    public string? resultado { get; set; }

    public static IEnumerable<AllExamesResponse> CreateResponse(List<Exame> exames)
    {
        foreach (var item in exames)
        {
            AllExamesResponse response = new(
                item.id,
                item.tipo,
                item.pacienteid,
                item.paciente.nome,
                item.data,
                item.hora,
                item.resultado
            );

            yield return response;
        }
    }
}
