using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedCare.Domain.Entities;

[Table("paciente")]
public class Paciente : BaseEntity
{
    public Paciente()
    {
        Procedimentos = new Collection<Procedimento>();
        Exames = new Collection<Exame>();
        Consultas = new Collection<Consulta>();
    }

    public Paciente(string nome, string cpf, string sexo, DateTime datanascimento, string endereco, string celular, string email)
    {
        this.nome = nome.Trim().ToUpper();
        this.cpf = cpf.Replace(".", "").Replace("-", "").Replace("/", "").Trim().ToUpper();
        this.sexo = sexo.Trim().ToUpper();
        this.datanascimento = datanascimento;
        this.endereco = endereco.Trim().ToUpper();
        this.celular = celular.Trim().ToUpper();
        this.email = email.Trim().ToUpper();
    }

    [StringLength(50)]
    public string nome { get; set; } = null!;
    [StringLength(40)]
    public string cpf { get; set; } = null!;
    [StringLength(20)]
    public string sexo { get; set; } = null!;
    [Column(TypeName = "date")]
    public DateTime datanascimento { get; set; }

    [StringLength(200)]
    public string endereco { get; set; } = null!;

    [StringLength(30)]
    public string celular { get; set; } = null!;

    [StringLength(200)]
    public string email { get; set; } = null!;

    public ICollection<Procedimento>? Procedimentos { get; set; }
    public ICollection<Exame>? Exames { get; set; }
    public ICollection<Consulta>? Consultas { get; set; }

    public void Atualizar(string nome, string cpf, string sexo, DateTime datanascimento, string endereco, string celular, string email)
    {
        this.nome = nome.Trim().ToUpper();
        this.cpf = cpf.Replace(".", "").Replace("-", "").Replace("/", "").Trim().ToUpper();
        this.sexo = sexo.Trim().ToUpper();
        this.datanascimento = datanascimento;
        this.endereco = endereco.Trim().ToUpper();
        this.celular = celular.Trim().ToUpper();
        this.email = email.Trim().ToUpper();
    }
}
