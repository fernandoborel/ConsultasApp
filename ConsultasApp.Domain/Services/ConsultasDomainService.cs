using ConsultasApp.Domain.Entities;
using ConsultasApp.Domain.Interfaces.Repositories;
using ConsultasApp.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace ConsultasApp.Domain.Services;

public class ConsultasDomainService : IConsultaDomainService
{
    private readonly IUnitOfWork _unitOfWork;

    public ConsultasDomainService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Consulta> Adicionar(Consulta consulta)
    {
        try
        {
            await _unitOfWork.ConsultaRepository.AddAsync(consulta);
            await _unitOfWork.SaveChangesAsync();
            return consulta;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro inesperado ao salvar a consulta: " + ex.Message, ex);
        }
    }

    public async Task<Consulta> Atualizar(Consulta consulta)
    {
        await _unitOfWork.ConsultaRepository.UpdateAsync(consulta);
        await _unitOfWork.SaveChangesAsync();
        return consulta;
    }

    public async Task<Consulta> Cancelar(Consulta consulta)
    {
        await _unitOfWork.ConsultaRepository.DeleteAsync(consulta);
        await _unitOfWork.SaveChangesAsync();
        return consulta;
    }

    public async Task<bool> ConsultaExisteAsync(int medicoId, DateTime dataHora)
    {
        return await _unitOfWork.ConsultaRepository.ConsultaExisteAsync(medicoId, dataHora);
    }

    public async Task<bool> MedicoEstaDisponivelAsync(int medicoId, DateTime dataHora)
    {
        return await _unitOfWork.MedicoRepository.MedicoEstaDisponivelAsync(medicoId, dataHora);
    }

    public async Task<(List<ConsultaResumo> Consultas, int TotalCount)> ObterConsultasPaginadasAsync(int pagina, int tamanhoPagina)
    {
        // Calcula o skip para paginação
        int skip = (pagina - 1) * tamanhoPagina;

        // Query base do repositório (supondo que tenha IQueryable para consultas)
        var query = _unitOfWork.ConsultaRepository
            .GetQueryable() // método que retorna IQueryable<Consulta>, implemente se não tiver
            .Include(c => c.Medico)
            .Include(c => c.Paciente);

        // Total de registros antes da paginação
        int totalCount = await query.CountAsync();

        // Aplica paginação e faz o select para o DTO ConsultaResumo
        var consultas = await query
            .OrderBy(c => c.DataHora)
            .Skip(skip)
            .Take(tamanhoPagina)
            .Select(c => new ConsultaResumo
            {
                ConsultaId = c.Id,
                NomeMedico = c.Medico.Nome,
                Especialidade = c.Medico.Especialidade,
                NomePaciente = c.Paciente.Nome,
                DataHora = c.DataHora
            })
            .ToListAsync();

        return (consultas, totalCount);
    }


    public async Task<Medico> ObterMedicoPorIdAsync(int medicoId)
    {
        return await _unitOfWork.MedicoRepository.ObterPorIdAsync(medicoId);
    }

    public async Task<Paciente> ObterPacientePorIdAsync(int pacienteId)
    {
        return await _unitOfWork.PacienteRepository.ObterPorIdAsync(pacienteId);
    }

    public async Task<Consulta> ObterPorId(int id)
    {
        return await _unitOfWork.ConsultaRepository.GetById(id);
    }

    public async Task<List<Consulta>> ObterTodos()
    {
        return await _unitOfWork.ConsultaRepository.GetAllAsync();
    }
}
