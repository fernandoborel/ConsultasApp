using ConsultasApp.Domain.Entities;

namespace ConsultasApp.Domain.Interfaces.Services;

public interface IPacienteDomainService
{
    Task<Paciente> Adicionar(Paciente paciente);
    Task<Paciente> Atualizar(Paciente paciente);
    Task<Paciente> ObterPorId(int id);
    Task<List<Paciente>> ObterTodos();
}