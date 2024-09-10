using MedCare.Domain.Entities;

namespace MedCare.Application.UseCases.FuncionarioCase.GetAllFuncionario;

public sealed record AllFuncionarioResponse
{
    public AllFuncionarioResponse(int funcionario_id, string nome, string cpf, string sexo, DateTime datanascimento, string cargo, string? registr_profissional, string? especialidade, 
        string endereco, string celular, string email)
    {
        this.funcionario_id = funcionario_id;
        this.nome = nome;
        this.cpf = cpf;
        this.sexo = sexo;
        this.datanascimento = datanascimento;
        this.cargo = cargo;
        this.registr_profissional = registr_profissional;
        this.especialidade = especialidade;
        this.endereco = endereco;
        this.celular = celular;
        this.email = email;
    }

    public int funcionario_id { get; set; }
    public string nome { get; set; } = null!;
    public string cpf { get; set; } = null!;

    public string sexo { get; set; } = null!;
    public DateTime datanascimento { get; set; }

    public string cargo { get; set; } = null!;
    public string? registr_profissional { get; set; }

    public string? especialidade { get; set; }

    public string endereco { get; set; } = null!;

    public string celular { get; set; } = null!;

    public string email { get; set; } = null!;

    public static IEnumerable<AllFuncionarioResponse> CreateResponse(List<Funcionario> funcionarios)
    {
        foreach (var item in funcionarios)
        {
            AllFuncionarioResponse response = new(
                item.id,
                item.nome,
                item.cpf,
                item.sexo,
                item.datanascimento,
                item.cargo,
                item.registr_profissional,
                item.especialidade,
                item.endereco,
                item.celular,
                item.email
            );

            yield return response;
        }
    }
}
