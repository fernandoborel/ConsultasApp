namespace ConsultasApp.Domain.Entities;

public class Medico
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public int AnosDeExperiencia { get; set; }

    public DateTime DataDeNascimento { get; set; }

    public int Crm { get; set; }

    public ICollection<Consulta> Consultas { get; set; }
}
