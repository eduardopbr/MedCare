using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.Domain.Entities;

[Table("funcionario")]
public class Funcionario : BaseEntity
{
    public Funcionario()
    {
        Procedimentos = new Collection<Procedimento>();
    }

    public Funcionario(string nome, string cpf, string sexo, DateTime datanascimento, string cargo, string? registr_profissional, string? especialidade, string endereco, string celular, string email)
    {
        this.nome = nome;
        this.cpf = cpf.Replace(".", "").Replace("-", "").Replace("/", "");
        this.sexo = sexo;
        this.datanascimento = datanascimento;
        this.cargo = cargo;
        this.registr_profissional = registr_profissional;
        this.especialidade = especialidade;
        this.endereco = endereco;
        this.celular = celular;
        this.email = email;
    }

    [StringLength(50)]
    public string nome { get; set; } = null!;
    [StringLength(40)]
    public string cpf { get; set; } = null!;

    [StringLength(20)]
    public string sexo { get; set; } = null!;
    [Column(TypeName = "date")]
    public DateTime datanascimento { get; set; }

    [StringLength(50)]
    public string cargo { get; set; } = null!;
    [StringLength(100)]
    public string? registr_profissional { get; set; }

    [StringLength(100)]
    public string? especialidade { get; set; }

    [StringLength(200)]
    public string endereco { get; set; } = null!;

    [StringLength(30)]
    public string celular { get; set; } = null!;

    [StringLength(200)]
    public string email { get; set; } = null!;

    public ICollection<Procedimento>? Procedimentos { get; set; }

    public void Atualizar(string nome, string cpf, string sexo, DateTime datanascimento, string cargo, string? registr_profissional, string? especialidade, string endereco, string celular, string email)
    {
        this.nome = nome;
        this.cpf = cpf.Replace(".", "").Replace("-", "").Replace("/", "");
        this.email = email;
        this.sexo = sexo;
        this.datanascimento = datanascimento;
        this.cargo = cargo;
        this.registr_profissional = registr_profissional;
        this.especialidade = especialidade;
        this.endereco = endereco;
        this.celular = celular;
        this.email = email;
    }

    public bool FuncionarioEhMedico()
    {
        return this.cargo == "medico";
    }
}
