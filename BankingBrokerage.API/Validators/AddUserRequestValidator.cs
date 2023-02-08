using FluentValidation;

namespace BankingBrokerage.API.Validators
{
    public class AddUserRequestValidator : AbstractValidator<Models.DTO.AddUserRequest>
    {
        public AddUserRequestValidator() 
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.PrimaryLocation).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.PermanentAddress).NotEmpty();
            RuleFor(x => x.GrossSalary).NotEmpty();
            RuleFor(x => x.Job).NotEmpty();
            RuleFor(x => x.JobLocation).NotEmpty();
        }
    }
}
