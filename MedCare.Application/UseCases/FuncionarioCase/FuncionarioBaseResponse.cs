namespace MedCare.Application.UseCases.FuncionarioCase
{
    public record FuncionarioBaseResponse
    {
        public int id {  get; set; }

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
    }
}
