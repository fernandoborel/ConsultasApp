using ConsultasApp.Domain.Entities;
using ConsultasApp.Domain.Interfaces.Repositories;
using ConsultasApp.Domain.Interfaces.Services;

namespace ConsultasApp.Domain.Services;

public class EnderecoDomainService(IUnitOfWork unitOfWork) : IEnderecoDomainService
{
    public async Task<Endereco> Adicionar(Endereco endereco)
    {
        try
        {
            await unitOfWork.EnderecoRepository.AddAsync(endereco);
            return endereco;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro inesperado ao salvar o endereço: " + ex.Message, ex);
        }
    }

    public async Task<Endereco> Atualizar(Endereco endereco)
    {
        await unitOfWork.EnderecoRepository.UpdateAsync(endereco);
        return endereco;
    }

    public async Task<Endereco> ObterPorId(int id)
    {
        return await unitOfWork.EnderecoRepository.GetById(id);
    }

    public async Task<List<Endereco>> ObterTodos()
    {
        return await unitOfWork.EnderecoRepository.GetAllAsync();
    }
}