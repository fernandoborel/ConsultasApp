using ConsultasApp.Application.Dtos.Request;
using ConsultasApp.Application.Dtos.Response;
using ConsultasApp.Application.Interfaces;
using ConsultasApp.Domain.Entities;
using ConsultasApp.Domain.Interfaces.Services;

namespace ConsultasApp.Application.Services;

public class EnderecoAppService : IEnderecoAppService
{
    private readonly IEnderecoDomainService _enderecoDomainService;

    public EnderecoAppService(IEnderecoDomainService enderecoDomainService)
    {
        _enderecoDomainService = enderecoDomainService;
    }

    public Task<EnderecoResponse> Adicionar(EnderecoRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<List<Endereco>> ObterTodos()
    {
        throw new NotImplementedException();
    }
}