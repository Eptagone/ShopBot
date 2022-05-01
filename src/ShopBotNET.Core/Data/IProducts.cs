// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using Telegram.BotAPI.InlineMode;
using Telegram.BotAPI.Payments;

namespace ShopBotNET.Core.Data
{
    public interface IProducts
    {
        /// <summary>
        /// Retrive all available products.
        /// </summary>
        /// <param name="providerToken">Provider token.</param>
        /// <returns>An IEnumerable of <see cref="InlineQueryResult"/></returns>
        IEnumerable<InlineQueryResult> GetProducts(string providerToken);

        /// <summary>
        /// Retrieve all available shipping options for a specific product.
        /// </summary>
        /// <param name="Id">Invoice payload</param>
        /// <returns>An IEnumerable of <see cref="ShippingOption"/></returns>
        IEnumerable<ShippingOption> GetShippingOptions(string payload, ShippingAddress address);
    }
}
