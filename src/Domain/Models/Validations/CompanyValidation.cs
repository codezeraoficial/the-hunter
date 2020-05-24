using Domain.Models.Validations.Docs;
using FluentValidation;

namespace Domain.Models.Validations
{
    public class CompanyValidation : AbstractValidator<Company>
    {
        public CompanyValidation()
        {

            RuleFor(f => f.Name)
                .NotEmpty().WithMessage("The field {PropertyName} must be provided")
                .Length(2, 100).WithMessage("The field {PropertyName} need to have between {MinLength} and {MaxLength} characteres");

            RuleFor(f => CnpjValidation.Validate(f.Document)).Equal(true)
                .WithMessage("O documento fornecido é inválido.");

        }
    }
}
