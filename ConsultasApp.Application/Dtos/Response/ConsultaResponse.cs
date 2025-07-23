namespace ConsultasApp.Application.Dtos.Response;

public class ConsultaResponse
{
    public int Id { get; set; }
    public int IdMedico { get; set; }
    public int IdPaciente { get; set; }
    public DateTime DataHora { get; set; }
}