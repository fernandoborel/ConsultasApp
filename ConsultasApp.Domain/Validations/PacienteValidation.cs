using ConsultasApp.Domain.Entities;
using FluentValidation;

namespace ConsultasApp.Domain.Validations;

public class PacienteValidation : AbstractValidator<Paciente>
{
    public PacienteValidation()
    {
        RuleFor(p => p.Nome)
            .NotEmpty().WithMessage("Nome é obrigatório.")
            .MaximumLength(150).WithMessage("Nome deve ter no máximo 150 caracteres.");

        RuleFor(p => p.Cpf)
            .NotEmpty().WithMessage("CPF é obrigatório.")
            .Length(11).WithMessage("CPF deve conter exatamente 11 dígitos.")
            .Matches("^[0-9]+$").WithMessage("CPF deve conter apenas números.");

        RuleFor(p => p.DataDeNascimento)
            .LessThan(DateTime.Now).WithMessage("A data de nascimento deve ser anterior à data atual.");
    }
}