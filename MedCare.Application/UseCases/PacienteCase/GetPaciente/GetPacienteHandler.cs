using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCare.Application.UseCases.PacienteCase.GetPaciente
{
    public class GetPacienteHandler : IRequestHandler<GetPacienteRequest, Response>
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public GetPacienteHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uof = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> Handle(GetPacienteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Paciente? paciente = await _uof.PacienteRepository.GetById(request.pacienteid, cancellationToken);

                if (paciente is null)
                    return new Response().AddError("Paciente não encontrado");

                return new Response(_mapper.Map<PacienteBaseResponse>(paciente));
            }
            catch (Exception ex)
            {
                return new Response().AddError(ex.Message);
            }
        }
    }
}
