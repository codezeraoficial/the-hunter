using FluentValidation;

namespace Domain.Models.Validations
{
    public class JobOfferValidation : AbstractValidator<JobOffer>
    {
        public JobOfferValidation()
        {
            RuleFor(j => j.Name)
             .NotEmpty().WithMessage("The field {PropertyName} must be provided")
             .Length(10, 50).WithMessage("The field {PropertyName} need to have between {MinLength} and {MaxLength} characteres");

            RuleFor(j => j.Description)
             .NotEmpty().WithMessage("The field {PropertyName} must be provided")
             .Length(50, 1000).WithMessage("The field {PropertyName} need to have between {MinLength} and {MaxLength} characteres");

            RuleFor(j => j.ContractTime)
             .NotEmpty().WithMessage("The field {PropertyName} must be provided");
        }
    }
}
