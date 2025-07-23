using ConsultasApp.Domain.Entities;
using ConsultasApp.Domain.Interfaces.Repositories;
using ConsultasApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ConsultasApp.Infra.Data.Repositories;

public class PacienteRepository : BaseRepository<Paciente>, IPacienteRepository
{
    public PacienteRepository(DataContext context) : base(context)
    {
    }

    public async Task<Paciente> ObterPorCpfAsync(string cpf)
    {
        return await _context.Pacientes
            .Include(p => p.Endereco)
            .FirstOrDefaultAsync(p => p.Cpf == cpf);
    }

    public async Task<Paciente> ObterPorIdAsync(int id)
    {
        return await _context.Pacientes
            .Include(p => p.Endereco)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}