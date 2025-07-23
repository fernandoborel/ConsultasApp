using ConsultasApp.Domain.Entities;
using ConsultasApp.Domain.Interfaces.Repositories;
using ConsultasApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ConsultasApp.Infra.Data.Repositories;

public class ConsultaRepository : BaseRepository<Consulta>, IConsultaRepository
{
    private readonly DataContext _context;

    public ConsultaRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> ConsultaExisteAsync(int medicoId, DateTime dataHora)
    {
        return await _context.Consultas
            .AnyAsync(c => c.MedicoId == medicoId && c.DataHora == dataHora);
    }

    public async Task<Consulta> ObterPorIdAsync(int id)
    {
        return await _context.Consultas
            .Include(c => c.Medico)
            .Include(c => c.Paciente)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Consulta>> ObterPorMedicoIdAsync(int medicoId)
    {
        return await _context.Consultas
            .Where(c => c.MedicoId == medicoId)
            .Include(c => c.Paciente)
            .ToListAsync();
    }
}