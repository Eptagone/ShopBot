// Copyright (c) 2024 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using Telegram.BotAPI;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.InlineMode;

namespace ShopBotNET.Application.Services;

/// <summary>
/// It contains the main functionality of the telegram bot. <br />
/// The application creates a new instance of this class to process each update received.
/// </summary>
partial class ShopBot : SimpleTelegramBotBase
{
    protected override void OnInlineQuery(InlineQuery iQuery)
    {
        var results = this
            .productService.GetAvailableOrders()
            .Select(p =>
            {
                var invoice = new InputInvoiceMessageContent(
                    p.Product.Name,
                    p.Product.Description,
                    Guid.NewGuid().ToString(),
                    p.Currency,
                    p.Prices
                )
                {
                    ProviderToken = this.providerToken,
                    PhotoUrl = p.Product.Photo.Url,
                    PhotoSize = p.Product.Photo.Size,
                    PhotoHeight = p.Product.Photo.Height,
                    PhotoWidth = p.Product.Photo.Width,
                    IsFlexible = p.IsFlexible,
                    NeedShippingAddress = p.NeedShippingAddress
                };

                if (p.MaxTipAmount != null)
                {
                    invoice.MaxTipAmount = p.MaxTipAmount;
                }
                if (p.SuggestedTipAmounts != null)
                {
                    invoice.SuggestedTipAmounts = p.SuggestedTipAmounts;
                }

                return new InlineQueryResultArticle
                {
                    Id = p.Product.Name,
                    Title = p.Product.Name,
                    Description = p.Product.Description,
                    ThumbnailUrl = p.Product.Photo.Url,
                    InputMessageContent = invoice
                };
            });

        this.client.AnswerInlineQuery(iQuery.Id, results, 30);
    }
}
