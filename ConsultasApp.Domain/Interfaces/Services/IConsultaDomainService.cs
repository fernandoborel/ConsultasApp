using ConsultasApp.Domain.Entities;

namespace ConsultasApp.Domain.Interfaces.Services;

public interface IConsultaDomainService
{
    Task<Consulta> Adicionar(Consulta consulta);
    Task<Consulta> Cancelar(Consulta consulta);
    Task<Consulta> Atualizar(Consulta consulta);
    Task<Consulta> ObterPorId(int id);
    Task<List<Consulta>> ObterTodos();

    Task<Medico> ObterMedicoPorIdAsync(int medicoId);
    Task<Paciente> ObterPacientePorIdAsync(int pacienteId);
    Task<bool> MedicoEstaDisponivelAsync(int medicoId, DateTime dataHora);
    Task<bool> ConsultaExisteAsync(int medicoId, DateTime dataHora);
}