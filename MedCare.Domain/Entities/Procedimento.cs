using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedCare.Domain.Entities;

[Table("procedimento")]
public class Procedimento : BaseEntity
{
    public Procedimento()
    {
        
    }
    public Procedimento(string tipo, int funcionarioid, int pacienteid, DateTime data, TimeSpan hora)
    {
        this.tipo = tipo;
        this.funcionarioid = funcionarioid;
        this.pacienteid = pacienteid;
        this.data = data;
        this.hora = hora;
    }

    [StringLength(50)]
    public string tipo { get; set; } = null!;

    public int funcionarioid { get; set; }
    public int pacienteid { get; set; }
    [Column(TypeName = "date")]
    public DateTime data {  get; set; }
    [Column(TypeName = "time without time zone")]
    public TimeSpan hora { get; set; }

    public Funcionario? funcionario {  get; set; }
    public Paciente? paciente {  get; set; }

    public void Atualizar(string tipo, int funcionarioid, int pacienteid, DateTime data, TimeSpan hora)
    {
        this.tipo = tipo;
        this.funcionarioid = funcionarioid;
        this.pacienteid = pacienteid;
        this.data = data;
        this.hora = hora;
    }
    
}
