using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedCare.Domain.Entities;

[Table("consulta")]
public class Consulta : BaseEntity
{
    public Consulta()
    {
        
    }
    public Consulta(int pacienteid, DateTime datanascimento, int funcionarioid, int registro, string especialidade, string diagnostico, string? examesrelacionados)
    {
        this.pacienteid = pacienteid;
        this.datanasc = datanascimento;
        this.funcionarioid = funcionarioid;
        this.registro = registro;
        this.especialidade = especialidade.Trim().ToUpper();
        this.diagnostico = diagnostico.Trim().ToUpper();
        this.examesrelacionados = examesrelacionados?.Trim().ToUpper();
    }
    public int pacienteid { get; set; }
    [Column(TypeName = "date")]
    public DateTime datanasc {  get; set; }
    public int funcionarioid { get; set; }
    public int registro { get; set; }
    [StringLength(100)]
    public string especialidade { get; set; } = null!;

    public string diagnostico { get; set; } = null!;

    [StringLength(100)]
    public string? examesrelacionados { get; set; }

    public void Atualizar(int pacienteid, DateTime datanascimento, int funcionarioid, int registro, string especialidade, string diagnostico, string? examesrelacionados)
    {
        this.pacienteid = pacienteid;
        this.datanasc = datanascimento;
        this.funcionarioid = funcionarioid;
        this.registro = registro;
        this.especialidade = especialidade.Trim().ToUpper();
        this.diagnostico = diagnostico.Trim().ToUpper();
        this.examesrelacionados = examesrelacionados?.Trim().ToUpper();
    }
}
