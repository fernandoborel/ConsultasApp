using ConsultasApp.Domain.Entities;

namespace ConsultasApp.Application.Dtos.Request;

public class PacienteRequest
{
    public string Nome { get; set; }
    public DateTime DataDeNascimento { get; set; }
    public string CPF { get; set; }
    public string Informacoes { get; set; }
    public EnderecoRequest Endereco { get; set; }
}