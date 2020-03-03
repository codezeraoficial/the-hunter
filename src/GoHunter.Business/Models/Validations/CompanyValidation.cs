using GoHunter.Business.Models.Validations.Docs;
using FluentValidation;

namespace GoHunter.Business.Models.Validations
{
    public class CompanyValidation : AbstractValidator<Company>
    {
        public CompanyValidation()
        {

            RuleFor(f => f.Name)
                .NotEmpty().WithMessage("The field {PropertyName} must be provided")
                .Length(2, 100).WithMessage("The field {PropertyName} need to have between {MinLength} and {MaxLength} characteres");

            RuleFor(f => f.Document.Length).Equal(CnpjValidation.CnpjLength)
                .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}");
            RuleFor(f => CnpjValidation.Validate(f.Document)).Equal(true)
                .WithMessage("O documento fornecido é inválido.");

        }
    }
}
