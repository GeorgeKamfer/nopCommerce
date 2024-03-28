﻿using FluentValidation;
using Nop.Core;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;
using Nop.Web.Models.ShoppingCart;

namespace Nop.Web.Validators.ShoppingCart;

public partial class WishlistEmailAFriendValidator : BaseNopValidator<WishlistEmailAFriendModel>
{
    public WishlistEmailAFriendValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.FriendEmail).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Wishlist.EmailAFriend.FriendEmail.Required"));
        RuleFor(x => x.FriendEmail)
            .EmailAddress()
            .Matches(CommonHelper.GetEmailRegex())
            .WithMessageAwait(localizationService.GetResourceAsync("Common.WrongEmail"));

        RuleFor(x => x.YourEmailAddress).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Wishlist.EmailAFriend.YourEmailAddress.Required"));
        RuleFor(x => x.YourEmailAddress)
            .EmailAddress()
            .Matches(CommonHelper.GetEmailRegex())
            .WithMessageAwait(localizationService.GetResourceAsync("Common.WrongEmail"));
    }
}