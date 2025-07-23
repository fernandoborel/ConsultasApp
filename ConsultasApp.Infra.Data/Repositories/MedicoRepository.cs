using ConsultasApp.Domain.Entities;
using ConsultasApp.Domain.Interfaces.Repositories;
using ConsultasApp.Infra.Data.Contexts;

namespace ConsultasApp.Infra.Data.Repositories;

public class MedicoRepository : BaseRepository<Medico>, IMedicoRepository
{
    public MedicoRepository(DataContext context) : base(context)
    {
        
    }
}