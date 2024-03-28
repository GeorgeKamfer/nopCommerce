using FluentValidation;
using Nop.Core;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Nop.Web.Models.Customer;

namespace Nop.Web.Validators.Customer;

public partial class PasswordRecoveryValidator : BaseNopValidator<PasswordRecoveryModel>
{
    public PasswordRecoveryValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.Email).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Account.PasswordRecovery.Email.Required"));
        RuleFor(x => x.Email)
            .EmailAddress()
            .Matches(CommonHelper.GetEmailRegex())
            .WithMessageAwait(localizationService.GetResourceAsync("Common.WrongEmail"));
    }
}