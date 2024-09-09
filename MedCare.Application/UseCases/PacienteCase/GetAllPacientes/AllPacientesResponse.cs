using MedCare.Domain.Entities;

namespace MedCare.Application.UseCases.PacienteCase.GetAllPacientes;

public sealed record AllPacientesResponse
{
    public AllPacientesResponse(int paciente_id, string nome)
    {
        this.paciente_id = paciente_id;
        this.nome = nome;
    }

    public int paciente_id { get; set; }
    public string nome { get; set; } = null!;

    public static IEnumerable<AllPacientesResponse> CreateResponse(List<Paciente> pacientes)
    {
        foreach (var item in pacientes)
        {
            AllPacientesResponse response = new(
                item.id,
                item.nome
            );

            yield return response;
        }
    }
}
