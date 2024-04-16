using AutoMapper;
using MedCare.Application.UseCases.ExameCase;
using MedCare.Application.UseCases.ExameCase.CreateExame;
using MedCare.Application.UseCases.ExameCase.UpdateExame;
using MedCare.Application.UseCases.FuncionarioCase;
using MedCare.Application.UseCases.FuncionarioCase.CreateFuncionario;
using MedCare.Application.UseCases.PacienteCase;
using MedCare.Application.UseCases.PacienteCase.CreatePaciente;
using MedCare.Application.UseCases.PacienteCase.UpdatePaciente;
using MedCare.Application.UseCases.ProcedimentoCase;
using MedCare.Application.UseCases.ProcedimentoCase.CreateProcedimento;
using MedCare.Application.UseCases.ProcedimentoCase.UpdateProcedimento;
using MedCare.Domain.Entities;

namespace MedCare.Application.UseCases.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreatePacienteRequest, Paciente>();
            CreateMap<Paciente, CreatePacienteResponse>();

            CreateMap<CreateFuncionarioRequest, Funcionario>();

            CreateMap<UpdatePacienteRequest, Paciente>();
            CreateMap<Paciente, UpdatePacienteResponse>();

            CreateMap<Paciente, PacienteBaseResponse>();

            CreateMap<Funcionario, FuncionarioBaseResponse>();

            CreateMap<CreateProcedimentoRequest, Procedimento>();
            CreateMap<UpdateProcedimentoRequest, Procedimento>();
            CreateMap<Procedimento, ProcedimentoBaseResponse>();

            CreateMap<CreateExameRequest, Exame>();
            CreateMap<UpdateExameRequest, Exame>();
            CreateMap<Exame, ExameBaseResponse>();
        }
    }
}
