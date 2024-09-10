using MedCare.Domain.Entities;

namespace MedCare.Application.UseCases.ExameCase.GetAllExames;

public sealed record AllExamesResponse
{
    public AllExamesResponse(int exame_id, string tipo)
    {
        this.exame_id = exame_id;
        this.tipo = tipo;
    }

    public int exame_id { get; set; }
    public string tipo { get; set; } = null!;

    public static IEnumerable<AllExamesResponse> CreateResponse(List<Exame> exames)
    {
        foreach (var item in exames)
        {
            AllExamesResponse response = new(
                item.id,
                item.tipo
            );

            yield return response;
        }
    }
}
