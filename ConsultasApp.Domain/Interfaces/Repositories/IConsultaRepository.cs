using ConsultasApp.Domain.Entities;

namespace ConsultasApp.Domain.Interfaces.Repositories;

public interface IConsultaRepository : IBaseRepository<Consulta>
{
    Task<bool> ConsultaExisteAsync(int medicoId, DateTime dataHora);
    Task<List<Consulta>> ObterPorMedicoIdAsync(int medicoId);
    Task<Consulta> ObterPorIdAsync(int id);
    IQueryable<Consulta> GetQueryable();
}