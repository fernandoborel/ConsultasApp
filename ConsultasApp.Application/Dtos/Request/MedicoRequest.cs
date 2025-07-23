namespace ConsultasApp.Application.Dtos.Request;

public class MedicoRequest
{
    public string Nome { get; set; }
    public int AnosDeExperiencia { get; set; }
    public int CRM { get; set; }
    public DateTime DataDeNascimento { get; set; }
    public DateTime HorariosDisponiveis { get; set; }
}