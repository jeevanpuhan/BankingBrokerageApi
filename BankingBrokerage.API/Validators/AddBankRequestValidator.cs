using FluentValidation;

namespace BankingBrokerage.API.Validators
{
    public class AddBankRequestValidator : AbstractValidator<Models.DTO.AddBankRequest>
    {
        public AddBankRequestValidator()
        {
            RuleFor(x => x.RoutingNumber).NotEmpty();
            RuleFor(x => x.BankType).NotEmpty();
            RuleFor(x => x.AccountNumber).NotEmpty();
            RuleFor(x => x.AccountType).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.AccountOwnerName).NotEmpty();
            RuleFor(x => x.Status).NotEmpty();
            RuleFor(x => x.PrimaryBank).NotEmpty();
            RuleFor(x => x.NickName).NotEmpty();
            RuleFor(x => x.CommunicationChannel).NotEmpty();

        }
    }
}
