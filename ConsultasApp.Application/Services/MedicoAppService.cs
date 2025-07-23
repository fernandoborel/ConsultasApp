using ConsultasApp.Application.Dtos.Request;
using ConsultasApp.Application.Dtos.Response;
using ConsultasApp.Application.Interfaces;
using ConsultasApp.Domain.Entities;
using ConsultasApp.Domain.Interfaces.Services;
using FluentValidation;

namespace ConsultasApp.Application.Services;

public class MedicoAppService : IMedicoAppService
{
    private readonly IMedicoDomainService _medicoDomainService;

    public MedicoAppService(IMedicoDomainService medicoDomainService)
    {
        _medicoDomainService = medicoDomainService;
    }

    public async Task<MedicoResponse> Adicionar(MedicoRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Nome))
            throw new ValidationException("Nome do médico é obrigatório.");

        if (request.AnosDeExperiencia < 0)
            throw new ValidationException("Anos de experiência inválido.");

        if (request.CRM <= 0)
            throw new ValidationException("CRM inválido.");

        var medico = new Medico
        {
            Nome = request.Nome,
            AnosDeExperiencia = request.AnosDeExperiencia,
            DataDeNascimento = request.DataDeNascimento,
            Crm = request.CRM,
            HorariosDisponiveis = request.HorariosDisponiveis
        };

        var medicoCadastrado = await _medicoDomainService.Adicionar(medico);

        return new MedicoResponse
        {
            Id = medicoCadastrado.Id,
            Nome = medicoCadastrado.Nome,
            AnosDeExperiencia = medicoCadastrado.AnosDeExperiencia,
            CRM = medicoCadastrado.Crm,
            DataDeNascimento = medicoCadastrado.DataDeNascimento,
            HorariosDisponiveis = medicoCadastrado.HorariosDisponiveis
        };
    }


    public async Task<List<Medico>> ObterTodos()
    {
        return await _medicoDomainService.ObterTodos();
    }
}