using ConsultasApp.Domain.Entities;

namespace ConsultasApp.Domain.Interfaces.Services;

public interface IMedicoDomainService
{
    Task<Medico> Adicionar(Medico medico);
    Task<Medico> Atualizar(Medico medico);
    Task<Medico> ObterPorId(int id);
    Task<List<Medico>> ObterTodos();
}