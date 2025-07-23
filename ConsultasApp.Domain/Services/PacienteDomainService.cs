using ConsultasApp.Domain.Entities;
using ConsultasApp.Domain.Interfaces.Repositories;
using ConsultasApp.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace ConsultasApp.Domain.Services; 

public class PacienteDomainService(IUnitOfWork unitOfWork) : IPacienteDomainService
{
    public async Task<Paciente> Adicionar(Paciente paciente)
    {
        try
        {
            await unitOfWork.PacienteRepository.AddAsync(paciente);
            return paciente;
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("Erro ao salvar o paciente: " + ex.InnerException?.Message, ex);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro inesperado ao salvar o solicitante: " + ex.Message, ex);
        }
    }

    public async Task<Paciente> Atualizar(Paciente paciente)
    {
        await unitOfWork.PacienteRepository.UpdateAsync(paciente);
        return paciente;
    }

    public async Task<Paciente> ObterPorCpfAsync(string cpf)
    {
        return await unitOfWork.PacienteRepository.ObterPorCpfAsync(cpf);
    }

    public async Task<Paciente> ObterPorId(int id)
    {
        return await unitOfWork.PacienteRepository.GetById(id);
    }

    public async Task<List<Paciente>> ObterTodos()
    {
        return await unitOfWork.PacienteRepository.GetAllAsync();
    }
}