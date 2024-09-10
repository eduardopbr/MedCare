using MedCare.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedCare.Application.UseCases.ProcedimentoCase.GetProcedimento;

public sealed record ProcedimentoResponse
{
    public ProcedimentoResponse(int procedimento_id, string tipo, int funcionarioid, string funcionario_nome, int pacienteid, string paciente_nome, DateTime data, TimeSpan hora)
    {
        this.procedimento_id = procedimento_id;
        this.tipo = tipo;
        this.funcionarioid = funcionarioid;
        this.funcionario_nome = funcionario_nome;
        this.pacienteid = pacienteid;
        this.paciente_nome = paciente_nome;
        this.data = data;
        this.hora = hora;
    }

    public int procedimento_id { get; set; }
    public string tipo { get; set; } = null!;

    public int funcionarioid { get; set; }
    public string funcionario_nome { get; set; } = null!;
    public int pacienteid { get; set; }
    public string paciente_nome { get; set; } = null!;
    public DateTime data { get; set; }
    public TimeSpan hora { get; set; }

    public static ProcedimentoResponse CreateResponse(Procedimento procedimento)
    {
        return new(
            procedimento.id,
            procedimento.tipo,
            procedimento.funcionarioid,
            procedimento.funcionario.nome,
            procedimento.pacienteid,
            procedimento.paciente.nome,
            procedimento.data, 
            procedimento.hora
        );
    }
}
