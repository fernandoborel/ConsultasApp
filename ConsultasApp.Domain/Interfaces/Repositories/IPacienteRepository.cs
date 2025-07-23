using ConsultasApp.Domain.Entities;

namespace ConsultasApp.Domain.Interfaces.Repositories;

public interface IPacienteRepository : IBaseRepository<Paciente>
{
    Task<Paciente> ObterPorIdAsync(int id);
    Task<Paciente> ObterPorCpfAsync(string cpf);
}