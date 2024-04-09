namespace MedCare.Application.UseCases.PacienteCase
{
    public record PacienteBaseResponse
    {
        public int id {  get; set; }

        public string nome { get; set; } = null!;
    }
}
