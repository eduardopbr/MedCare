namespace MedCare.Application.UseCases.ConsultaCase
{
    public sealed record ConsultaBaseResponse
    {
        public int id { get; set; }
        public int pacienteid { get; set; }
        public DateTime datanasc { get; set; }
        public int funcionarioid { get; set; }
        public int registro { get; set; }
        public string especialidade { get; set; } = null!;

        public string diagnostico { get; set; } = null!;

        public string? examesrelacionados { get; set; }
    }
}
