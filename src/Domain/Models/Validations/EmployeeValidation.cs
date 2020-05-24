using FluentValidation;
using Domain.Models.Validations.Docs;

namespace Domain.Models.Validations
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
                       
            RuleFor(f => CpfValidation.Validate(f.Document)).Equal(true)
                .WithMessage("O documento fornecido é inválido.");
        }
    }
}
