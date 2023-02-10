using FluentValidation;

namespace BankingBrokerage.API.Validators
{
    public class AddBankRequestValidator : AbstractValidator<Models.DTO.AddBankRequest>
    {
        public AddBankRequestValidator()
        {
            RuleFor(x => x.RoutingNumber)
                .NotEmpty()
                .Length(9).WithMessage("Routing Number must be of 9 digits long");
            RuleFor(x => x.BankType).NotEmpty();
            RuleFor(x => x.AccountNumber)
                .NotEmpty()
                .Length(10,16).WithMessage("Account number must be between 10 to 16 digits long");
            RuleFor(x => x.AccountType).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.AccountOwnerName)
                .NotEmpty()
                .Matches("^[0-9a-zA-Z ]+$")
                .WithMessage("Account Owner Name is invalid");
            RuleFor(x => x.Status).NotEmpty();
            RuleFor(x => x.PrimaryBank).NotNull();
            RuleFor(x => x.NickName).NotEmpty();
            RuleFor(x => x.CommunicationChannel).NotEmpty();

        }
    }
}
