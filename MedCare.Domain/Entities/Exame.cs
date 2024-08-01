using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedCare.Domain.Entities;

[Table("exame")]
public class Exame : BaseEntity
{
    public Exame()
    {
        
    }
    public Exame(string tipo, int pacienteid, DateTime data, TimeSpan hora, string? resultado)
    {
        this.tipo = tipo;
        this.pacienteid = pacienteid;
        this.data = data;
        this.hora = hora;
        this.resultado = resultado;
    }

    [StringLength(50)]
    public string tipo { get; set; }

    public int pacienteid { get; set; }

    [Column(TypeName = "date")]
    public DateTime data { get; set; }
    [Column(TypeName = "time without time zone")]
    public TimeSpan hora { get; set; }

    public string? resultado { get; set; }

    public Paciente? paciente { get; set; }

    public void Atualizar(string tipo, int pacienteid, DateTime data, TimeSpan hora, string? resultado)
    {
        this.tipo = tipo;
        this.pacienteid = pacienteid;
        this.data = data;
        this.hora = hora;
        this.resultado = resultado;
    }
}
