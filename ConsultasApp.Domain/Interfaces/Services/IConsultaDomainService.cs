using ConsultasApp.Domain.Entities;

namespace ConsultasApp.Domain.Interfaces.Services;

public interface IConsultaDomainService
{
    Task<Consulta> Adicionar(Consulta consulta);
    Task<Consulta> Cancelar(Consulta consulta);
    Task<Consulta> Atualizar(Consulta consulta);
    Task<Consulta> ObterPorId(int id);
    Task<List<Consulta>> ObterTodos();

    Task<(List<ConsultaResumo> Consultas, int TotalCount)> ObterConsultasPaginadasAsync(int pagina, int tamanhoPagina);
    Task<Medico> ObterMedicoPorIdAsync(int medicoId);
    Task<Paciente> ObterPacientePorIdAsync(int pacienteId);
    Task<bool> MedicoEstaDisponivelAsync(int medicoId, DateTime dataHora);
    Task<bool> ConsultaExisteAsync(int medicoId, DateTime dataHora);
}

public class ConsultaResumo
{
    public int ConsultaId { get; set; }
    public string NomeMedico { get; set; }
    public string Especialidade { get; set; }
    public string NomePaciente { get; set; }
    public DateTime DataHora { get; set; }
}