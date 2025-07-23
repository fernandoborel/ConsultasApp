using ConsultasApp.Domain.Entities;

namespace ConsultasApp.Domain.Interfaces.Services;

public interface IEnderecoDomainService
{
    Task<Endereco> Adicionar(Endereco endereco);
    Task<Endereco> Atualizar(Endereco endereco);
    Task<Endereco> ObterPorId(int id);
    Task<List<Endereco>> ObterTodos();
}
