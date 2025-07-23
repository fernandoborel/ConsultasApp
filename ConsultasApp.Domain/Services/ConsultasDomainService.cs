using ConsultasApp.Domain.Entities;
using ConsultasApp.Domain.Interfaces.Repositories;
using ConsultasApp.Domain.Interfaces.Services;

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
