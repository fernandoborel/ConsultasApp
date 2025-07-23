using ConsultasApp.Domain.Entities;
using ConsultasApp.Domain.Interfaces.Repositories;
using ConsultasApp.Domain.Interfaces.Services;

namespace ConsultasApp.Domain.Services;

public class MedicoDomainService(IUnitOfWork unitOfWork) : IMedicoDomainService
{
    public async Task<Medico> Adicionar(Medico medico)
    {
        try
        {
            await unitOfWork.MedicoRepository.AddAsync(medico);
            return medico;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro inesperado ao salvar o médico: " + ex.Message, ex);
        }
    }

    public async Task<Medico> Atualizar(Medico medico)
    {
        await unitOfWork.MedicoRepository.UpdateAsync(medico);
        return medico;
    }

    public async Task<Medico> ObterPorId(int id)
    {
        return await unitOfWork.MedicoRepository.GetById(id);
    }

    public async Task<List<Medico>> ObterTodos()
    {
        return await unitOfWork.MedicoRepository.GetAllAsync();
    }
}