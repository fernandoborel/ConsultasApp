using ConsultasApp.Application.Dtos.Request;
using ConsultasApp.Application.Dtos.Response;
using ConsultasApp.Domain.Entities;

namespace ConsultasApp.Application.Interfaces;

public interface IEnderecoAppService
{
    Task<EnderecoResponse> Adicionar(EnderecoRequest request);
    Task<List<Endereco>> ObterTodos();
}