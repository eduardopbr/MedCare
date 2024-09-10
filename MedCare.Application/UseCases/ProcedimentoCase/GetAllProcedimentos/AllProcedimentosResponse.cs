using MedCare.Domain.Entities;

namespace MedCare.Application.UseCases.ProcedimentoCase.GetAllProcedimentos;

public class AllProcedimentosResponse
{
    public AllProcedimentosResponse(int procedimento_id, string tipo)
    {
        this.procedimento_id = procedimento_id;
        this.tipo = tipo;
    }

    public int procedimento_id { get; set; }
    public string tipo { get; set; } = null!;

    public static IEnumerable<AllProcedimentosResponse> CreateResponse(List<Procedimento> procedimentos)
    {
        foreach (var item in procedimentos)
        {
            AllProcedimentosResponse response = new(
                item.id,
                item.tipo
            );

            yield return response;
        }
    }
}
