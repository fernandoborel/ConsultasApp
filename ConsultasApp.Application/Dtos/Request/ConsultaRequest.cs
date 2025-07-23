namespace ConsultasApp.Application.Dtos.Request;

public class ConsultaRequest
{
    public int IdMedico { get; set; }
    public int IdPaciente { get; set; }
    public DateTime DataHora { get; set; }
}