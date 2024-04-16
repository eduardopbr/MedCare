namespace MedCare.Application.UseCases.ExameCase
{
    public sealed record ExameBaseResponse
    {
        public int id { get; set; }
        public required string tipo { get; set; }

        public int pacienteid { get; set; }

        public DateTime data { get; set; }
        public TimeSpan hora { get; set; }

        public string? resultado { get; set; }
    }
}
