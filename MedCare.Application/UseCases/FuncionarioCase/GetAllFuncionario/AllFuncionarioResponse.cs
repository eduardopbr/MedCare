using MedCare.Domain.Entities;

namespace MedCare.Application.UseCases.FuncionarioCase.GetAllFuncionario;

public sealed record AllFuncionarioResponse
{
    public AllFuncionarioResponse(int funcionario_id, string funcionario_nome)
    {
        this.funcionario_id = funcionario_id;
        this.funcionario_nome = funcionario_nome;
    }

    public int funcionario_id { get; set; }
    public string funcionario_nome { get; set; } = null!;

    public static IEnumerable<AllFuncionarioResponse> CreateResponse(List<Funcionario> funcionarios)
    {
        foreach (var item in funcionarios)
        {
            AllFuncionarioResponse response = new(
                item.id,
                item.nome
            );

            yield return response;
        }
    }
}
