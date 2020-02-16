using FluentValidation;

namespace GoHunter.Business.Models.Validations
{
    public class AddressValidation: AbstractValidator<Address>
    {
        public AddressValidation()
        {
            RuleFor(c => c.Street)
                .NotEmpty().WithMessage("The field {PropertyName} must be provided")
                .Length(2, 200).WithMessage("The field {PropertyName} need to have between {MinLength} and {MaxLength} characteres");

            RuleFor(c => c.Neighborhood)
                .NotEmpty().WithMessage("The field {PropertyName} must be provided")
                .Length(2, 100).WithMessage("The field {PropertyName} need to have between {MinLength} and {MaxLength} characteres");

            RuleFor(c => c.Cep)
                .NotEmpty().WithMessage("The field {PropertyName} must be provided")
                .Length(8).WithMessage("The field {PropertyName} need to have between {MinLength} and {MaxLength} characteres");

            RuleFor(c => c.City)
                .NotEmpty().WithMessage("The field {PropertyName} must be provided")
                .Length(2, 100).WithMessage("The field {PropertyName} need to have between {MinLength} and {MaxLength} characteres");

            RuleFor(c => c.State)
                .NotEmpty().WithMessage("The field {PropertyName} must be provided")
                .Length(2, 50).WithMessage("The field {PropertyName} need to have between {MinLength} and {MaxLength} characteres");

            RuleFor(c => c.Number)
                .NotEmpty().WithMessage("The field {PropertyName} must be provided")
                .Length(2, 50).WithMessage("The field {PropertyName} need to have between {MinLength} and {MaxLength} characteres");
        }
    }
}
