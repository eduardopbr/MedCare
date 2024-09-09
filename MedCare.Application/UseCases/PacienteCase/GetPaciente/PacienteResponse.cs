using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MedCare.Domain.Entities;

namespace MedCare.Application.UseCases.PacienteCase.GetPaciente;

public sealed record PacienteResponse
{
    public PacienteResponse(int paciente_id, string nome, string cpf, string sexo, DateTime datanascimento, string endereco, string celular, string email)
    {
        this.paciente_id = paciente_id;
        this.nome = nome;
        this.cpf = cpf;
        this.sexo = sexo;
        this.datanascimento = datanascimento;
        this.endereco = endereco;
        this.celular = celular;
        this.email = email;
    }

    public int paciente_id { get; set; }
    public string nome { get; set; } = null!;
    public string cpf { get; set; } = null!;
    public string sexo { get; set; } = null!;
    public DateTime datanascimento { get; set; }

    public string endereco { get; set; } = null!;

    public string celular { get; set; } = null!;

    public string email { get; set; } = null!;

    public static PacienteResponse CreateResponse(Paciente paciente)
    {
        return new(
            paciente.id,
            paciente.nome,
            paciente.cpf,
            paciente.sexo,
            paciente.datanascimento,
            paciente.endereco,
            paciente.celular,
            paciente.email
        );
    }
}
