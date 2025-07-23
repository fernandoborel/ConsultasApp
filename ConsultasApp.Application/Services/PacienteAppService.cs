using ConsultasApp.Application.Dtos.Request;
using ConsultasApp.Application.Dtos.Response;
using ConsultasApp.Application.Interfaces;
using ConsultasApp.Domain.Entities;
using ConsultasApp.Domain.Interfaces.Services;
using ConsultasApp.Domain.Validations;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace ConsultasApp.Application.Services;

public class PacienteAppService : IPacienteAppService
{
    private readonly IPacienteDomainService _pacienteDomainService;
    private readonly ViaCepService _viaCepService;

    public PacienteAppService(IPacienteDomainService pacienteDomainService, ViaCepService viaCepService)
    {
        _pacienteDomainService = pacienteDomainService;
        _viaCepService = viaCepService;
    }

    public async Task<PacienteResponse> Adicionar(PacienteRequest request)
    {
        var cep = request.Endereco.Cep?.Trim();

        var enderecoViaCep = await _viaCepService.ObterEnderecoPorCepAsync(cep);
        if (enderecoViaCep == null)
            throw new ApplicationException("CEP inválido ou não encontrado.");

        if (request.Endereco.Numero <= 0)
            throw new ValidationException("Número do endereço deve ser maior que zero.");

        var endereco = new Endereco
        {
            Logradouro = enderecoViaCep.Logradouro,
            Numero = request.Endereco.Numero,
            Cep = enderecoViaCep.Cep,
            Municipio = enderecoViaCep.Localidade,
            Uf = enderecoViaCep.Uf
        };

        var paciente = new Paciente
        {
            Nome = request.Nome,
            Cpf = request.CPF,
            DataDeNascimento = request.DataDeNascimento,
            Informacoes = request.Informacoes ?? "",
            Endereco = endereco
        };


        var validator = new PacienteValidation();
        var result = validator.Validate(paciente);
        if (!result.IsValid)
            throw new ValidationException(string.Join("; ", result.Errors.Select(e => e.ErrorMessage)));

        var existente = await _pacienteDomainService.ObterPorCpfAsync(request.CPF);
        if (existente != null)
            throw new ApplicationException("Já existe um paciente cadastrado com este CPF.");

        var pacienteCadastrado = await _pacienteDomainService.Adicionar(paciente);

        return new PacienteResponse
        {
            Id = pacienteCadastrado.Id,
            Nome = pacienteCadastrado.Nome,
            CPF = pacienteCadastrado.Cpf,
            Informacoes = pacienteCadastrado.Informacoes,
            DataDeNascimento = pacienteCadastrado.DataDeNascimento,
            Endereco = new EnderecoResponse
            {
                Logradouro = pacienteCadastrado.Endereco.Logradouro,
                Numero = pacienteCadastrado.Endereco.Numero,
                Cep = pacienteCadastrado.Endereco.Cep,
                Municipio = pacienteCadastrado.Endereco.Municipio,
                Uf = pacienteCadastrado.Endereco.Uf
            }
        };
    }



    public async Task<List<Paciente>> ObterTodos()
    {
        return await _pacienteDomainService.ObterTodos();
    }
}

public class ViaCepService
{
    private readonly HttpClient _httpClient;

    public ViaCepService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ViaCepResponse?> ObterEnderecoPorCepAsync(string cep)
    {
        cep = cep.Replace("-", "").Trim();
        var url = $"https://viacep.com.br/ws/{cep}/json/";

        var response = await _httpClient.GetAsync(url);
        if (!response.IsSuccessStatusCode)
            return null;

        var json = await response.Content.ReadAsStringAsync();
        var endereco = JsonSerializer.Deserialize<ViaCepResponse>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if (endereco != null && endereco.Erro)
            return null;

        return endereco;
    }
}

public class ViaCepResponse
{
    public string Cep { get; set; }
    public string Logradouro { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string Localidade { get; set; }  // Municipio
    public string Uf { get; set; }
    public bool Erro { get; set; }
}