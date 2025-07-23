namespace ConsultasApp.Application.Dtos.Response;

public class PacienteResponse
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataDeNascimento { get; set; }
    public string CPF { get; set; }
    public string Informacoes { get; set; }
    public EnderecoResponse Endereco { get; set; }
}