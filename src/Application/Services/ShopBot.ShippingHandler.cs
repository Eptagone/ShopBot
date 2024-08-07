﻿// Copyright (c) 2024 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.Payments;

namespace ShopBotNET.Application.Services;

/// <summary>
/// It contains the main functionality of the telegram bot. <br />
/// The application creates a new instance of this class to process each update received.
/// </summary>
partial class ShopBot : SimpleTelegramBotBase
{
    protected override void OnShippingQuery(ShippingQuery sQuery)
    {
        // In Production you mush check sQuery.ShippingAddress before return shipping options. Also use `sQuery.InvoicePayload` to track the order
        var options = this.shippingService.GetShippingOptions();

        this.client.AnswerShippingQuery(sQuery.Id, true, options);
    }

    protected override void OnPreCheckoutQuery(PreCheckoutQuery pQuery)
    {
        // In Producttion, check all thinks are done. Example: inventory, etc
        this.client.AnswerPreCheckoutQuery(pQuery.Id, true);
    }
}
