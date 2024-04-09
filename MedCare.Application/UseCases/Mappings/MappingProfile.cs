using AutoMapper;
using MedCare.Application.UseCases.PacienteCase.CreatePaciente;
using MedCare.Domain.Entities;

namespace MedCare.Application.UseCases.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreatePacienteRequest, Paciente>();
            CreateMap<Paciente, CreatePacienteResponse>();
        }
    }
}
