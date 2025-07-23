using ConsultasApp.Domain.Entities;

namespace ConsultasApp.Domain.Interfaces.Services;

public interface IConsultaDomainService
{
    Task<Consulta> Adicionar(Consulta consulta);
    Task<Consulta> Cancelar(Consulta consulta);
    Task<Consulta> Atualizar(Consulta consulta);
    Task<Consulta> ObterPorId(int id);
    Task<List<Consulta>> ObterTodos();
}