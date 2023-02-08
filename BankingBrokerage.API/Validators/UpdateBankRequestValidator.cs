using FluentValidation;

namespace BankingBrokerage.API.Validators
{
    public class UpdateBankRequestValidator : AbstractValidator<Models.DTO.UpdateBankRequest>
    {
        public UpdateBankRequestValidator() 
        {
            RuleFor(x => x.AccountOwnerName).NotEmpty();
            RuleFor(x => x.NickName).NotEmpty();
        }
    }
}
