namespace MedCare.Application.UseCases.ProcedimentoCase
{
    public sealed record ProcedimentoBaseResponse
    {
        public int id { get; set; }
        public string tipo { get; set; } = null!;

        public int funcionarioid { get; set; }
        public int pacienteid { get; set; }
        public DateTime data { get; set; }
        public TimeSpan hora { get; set; }
    }
}
