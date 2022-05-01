// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using Telegram.BotAPI;
using Telegram.BotAPI.InlineMode;

namespace ShopBotNET.Core.Services
{
    /// <summary>
    /// It contains the main functionality of the telegram bot. <br />
    /// The application creates a new instance of this class to process each update received.
    /// </summary>
    public partial class ShopBot : TelegramBotBase<ShopBotProperties>
    {
        protected override void OnInlineQuery(InlineQuery iQuery)
        {
            var results = _db.Products.GetProducts(Properties.ProviderToken);

            Api.AnswerInlineQuery(iQuery.Id, results, 30);
        }
    }
}
