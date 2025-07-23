using ConsultasApp.Application.Dtos.Request;
using ConsultasApp.Application.Dtos.Response;
using ConsultasApp.Application.Interfaces;
using ConsultasApp.Domain.Entities;
using ConsultasApp.Domain.Interfaces.Services;

namespace ConsultasApp.Application.Services;

public class ConsultaAppService : IConsultaAppService
{
    private readonly IConsultaDomainService _consultaDomainService;
    private readonly IMedicoDomainService _medicoDomainService;
    private readonly IPacienteDomainService _pacienteDomainService;

    public ConsultaAppService(
        IConsultaDomainService consultaDomainService,
        IMedicoDomainService medicoDomainService,
        IPacienteDomainService pacienteDomainService)
    {
        _consultaDomainService = consultaDomainService;
        _medicoDomainService = medicoDomainService;
        _pacienteDomainService = pacienteDomainService;
    }

    public async Task<ConsultaResponse> Adicionar(ConsultaRequest request)
    {
        if (request.IdMedico <= 0)
            throw new ApplicationException("Médico deve ser selecionado.");

        if (request.IdPaciente <= 0)
            throw new ApplicationException("Paciente deve ser selecionado.");

        if (request.DataHora == default)
            throw new ApplicationException("Horário deve ser informado.");

        var medico = await _medicoDomainService.ObterPorId(request.IdMedico);
        if (medico == null)
            throw new ApplicationException("Médico não encontrado.");

        var paciente = await _pacienteDomainService.ObterPorId(request.IdPaciente);
        if (paciente == null)
            throw new ApplicationException("Paciente não encontrado.");


        var estaDisponivel = await _consultaDomainService.MedicoEstaDisponivelAsync(request.IdMedico, request.DataHora);
        if (!estaDisponivel)
            throw new ApplicationException("Médico não está disponível neste horário.");

        var consultaExistente = await _consultaDomainService.ConsultaExisteAsync(request.IdMedico, request.DataHora);
        if (consultaExistente)
            throw new ApplicationException("Já existe um agendamento para este médico neste horário.");

        var consulta = new Consulta
        {
            MedicoId = request.IdMedico,
            PacienteId = request.IdPaciente,
            DataHora = request.DataHora
        };

        var consultaCriada = await _consultaDomainService.Adicionar(consulta);

        return new ConsultaResponse
        {
            Id = consultaCriada.Id,
            IdMedico = consultaCriada.MedicoId,
            IdPaciente = consultaCriada.PacienteId,
            DataHora = consultaCriada.DataHora
        };
    }

    public async Task<List<Consulta>> ObterTodos()
    {
        return await _consultaDomainService.ObterTodos();
    }
}