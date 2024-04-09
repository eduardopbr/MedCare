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

namespace MedCare.Application.UseCases.PacienteCase.CreatePaciente
{
    public class CreatePacienteHandler : IRequestHandler<CreatePacienteRequest, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePacienteHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response> Handle(CreatePacienteRequest request, CancellationToken cancellationToken)
        {
            var paciente = _mapper.Map<Paciente>(request);

            try 
            {
                _unitOfWork.PacienteRepository.Add(paciente);

                await _unitOfWork.Commit(cancellationToken);
                return new Response(_mapper.Map<CreatePacienteResponse>(paciente));
            }
            catch (Exception ex) 
            {
                return new Response().AddError(ex.Message);
            }
        }
    }
}
