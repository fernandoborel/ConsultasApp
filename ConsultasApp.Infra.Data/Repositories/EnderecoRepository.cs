using ConsultasApp.Domain.Entities;
using ConsultasApp.Domain.Interfaces.Repositories;
using ConsultasApp.Infra.Data.Contexts;

namespace ConsultasApp.Infra.Data.Repositories;

public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
{
    public EnderecoRepository(DataContext context) : base(context)
    {
    }
}