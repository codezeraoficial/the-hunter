using FluentValidation;
using GoHunter.Business.Models.Validations.Docs;

namespace GoHunter.Business.Models.Validations
{
    public class EmployeeValidation: AbstractValidator<Employee>
    {
        public EmployeeValidation()
        {

            RuleFor(e => e.FirstName)
               .NotEmpty().WithMessage("The field {PropertyName} must be provided")
               .Length(2, 50).WithMessage("The field {PropertyName} need to have between {MinLength} and {MaxLength} characteres");

            RuleFor(e => e.LastName)
               .NotEmpty().WithMessage("The field {PropertyName} must be provided")
               .Length(2, 50).WithMessage("The field {PropertyName} need to have between {MinLength} and {MaxLength} characteres");

            RuleFor(e => e.Document.Length).Equal(CpfValidation.CpfLength)
                .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}");
            RuleFor(f => CnpjValidacao.Validar(f.Document)).Equal(true)
                .WithMessage("O documento fornecido é inválido.");
        }
    }
}
