using MedCare.Domain.Entities;

namespace MedCare.Application.UseCases.ExameCase.GetExame;

public sealed record ExameResponse
{
    public ExameResponse(int exame_id, string tipo, int pacienteid, string paciente_nome, DateTime data, TimeSpan hora, string? resultado)
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

    public static ExameResponse CreateResponse(Exame exame)
    {
        return new(
            exame.id,
            exame.tipo,
            exame.pacienteid,
            exame.paciente.nome,
            exame.data,
            exame.hora,
            exame.resultado
        );
    }
}
