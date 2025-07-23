using ConsultasApp.Domain.Entities;
using ConsultasApp.Domain.Interfaces.Repositories;
using ConsultasApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ConsultasApp.Infra.Data.Repositories;

public class MedicoRepository : BaseRepository<Medico>, IMedicoRepository
{
    private readonly DataContext _context;

    public MedicoRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> MedicoEstaDisponivelAsync(int medicoId, DateTime dataHora)
    {
        // Verifica se já existe uma consulta para o médico no horário informado
        return !await _context.Consultas
            .AnyAsync(c => c.MedicoId == medicoId && c.DataHora == dataHora);
    }

    public async Task<bool> MedicoExisteAsync(int medicoId)
    {
        return await _context.Medicos.AnyAsync(m => m.Id == medicoId);
    }

    public async Task<Medico> ObterPorIdAsync(int id)
    {
        return await _context.Medicos
            .Include(m => m.Consultas)
            .FirstOrDefaultAsync(m => m.Id == id);
    }
}