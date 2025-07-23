using ConsultasApp.Domain.Interfaces.Repositories;
using ConsultasApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore.Storage;

namespace ConsultasApp.Infra.Data.Repositories;

public class UnitOfWork(DataContext _context) : IUnitOfWork
{
    private IDbContextTransaction _transaction;

    public IEnderecoRepository EnderecoRepository => new EnderecoRepository(_context);

    public IConsultaRepository ConsultaRepository => new ConsultaRepository(_context);

    public IMedicoRepository MedicoRepository => new MedicoRepository(_context);

    public IPacienteRepository PacienteRepository => new PacienteRepository(_context);

    public void BeginTransaction()
    {
        _transaction = _context.Database.BeginTransaction();
    }

    public void Commit()
    {
        _transaction?.Commit();
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _context?.Dispose();
    }

    public void Rollback()
    {
        _transaction?.Rollback();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}