using ConsultasApp.Domain.Entities;

namespace ConsultasApp.Domain.Interfaces.Repositories;

public interface IMedicoRepository : IBaseRepository<Medico>
{
    Task<Medico> ObterPorIdAsync(int id);
    Task<bool> MedicoExisteAsync(int medicoId);
    Task<bool> MedicoEstaDisponivelAsync(int medicoId, DateTime dataHora);
}