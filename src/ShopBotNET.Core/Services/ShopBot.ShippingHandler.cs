// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using Telegram.BotAPI;
using Telegram.BotAPI.Payments;

namespace ShopBotNET.Core.Services
{
    /// <summary>
    /// It contains the main functionality of the telegram bot. <br />
    /// The application creates a new instance of this class to process each update received.
    /// </summary>
    public partial class ShopBot : TelegramBotBase<ShopBotProperties>
    {
        protected override void OnShippingQuery(ShippingQuery sQuery)
        {
            // In Production you mush check sQuery.ShippingAddress before return shipping options
            var options = _db.Products.GetShippingOptions(sQuery.InvoicePayload, sQuery.ShippingAddress);

            Api.AnswerShippingQuery(sQuery.Id, true, options);
        }

        protected override void OnPreCheckoutQuery(PreCheckoutQuery pQuery)
        {
            // In Producttion, check all thinks are done. Example: inventory, etc
            Api.AnswerPreCheckoutQuery(pQuery.Id, true);
        }
    }
}
