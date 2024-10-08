﻿using AutoMapper;
using MedCare.Application.Shared.Behavior;
using MedCare.Domain.Entities;
using MedCare.Domain.Interfaces;
using MediatR;

namespace MedCare.Application.UseCases.FuncionarioCase.GetAllFuncionario;

public class GetAllFuncionariosHandler : IRequestHandler<GetAllFuncionariosRequest, Response>
{
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;

    public GetAllFuncionariosHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _uof = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Response> Handle(GetAllFuncionariosRequest request, CancellationToken cancellationToken)
    {
        try
        {
            List<Funcionario> funcionarios = await _uof.FuncionarioRepository.GetAll(cancellationToken);

            List<AllFuncionarioResponse> response = AllFuncionarioResponse.CreateResponse(funcionarios).ToList();

            return new Response(response);
        }
        catch (Exception ex)
        {
            return new Response(CodeStateResponse.Error).AddError(ex.Message);
        }
    }
}
