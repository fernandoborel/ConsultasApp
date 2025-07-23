using ConsultasApp.Domain.Entities;
using ConsultasApp.Domain.Interfaces.Repositories;
using ConsultasApp.Domain.Interfaces.Services;

namespace ConsultasApp.Domain.Services;

public class ConsultasDomainService(IUnitOfWork unitOfWork) : IConsultaDomainService
{
    public async Task<Consulta> Adicionar(Consulta consulta)
    {
        try
        {
            await unitOfWork.ConsultaRepository.AddAsync(consulta);
            return consulta;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro inesperado ao salvar a consulta: " + ex.Message, ex);
        }
    }

    public async Task<Consulta> Atualizar(Consulta consulta)
    {
        await unitOfWork.ConsultaRepository.UpdateAsync(consulta);
        return consulta;
    }

    public async Task<Consulta> Cancelar(Consulta consulta)
    {
        await unitOfWork.ConsultaRepository.DeleteAsync(consulta);
        return consulta;
    }

    public async Task<Consulta> ObterPorId(int id)
    {
        return await unitOfWork.ConsultaRepository.GetById(id);
    }

    public async Task<List<Consulta>> ObterTodos()
    {
        return await unitOfWork.ConsultaRepository.GetAllAsync();
    }
}