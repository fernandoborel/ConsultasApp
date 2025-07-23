namespace ConsultasApp.Domain.Interfaces.Repositories;

public interface IUnitOfWork : IDisposable
{
    Task SaveChangesAsync();
    void BeginTransaction();
    void Commit();
    void Rollback();

    IEnderecoRepository EnderecoRepository { get; }
    IConsultaRepository ConsultaRepository { get; }
    IMedicoRepository MedicoRepository { get; }
    IPacienteRepository PacienteRepository { get; }
}