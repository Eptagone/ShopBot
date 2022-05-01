// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using ShopBotNET.Core.Entities;

namespace ShopBotNET.Core.Data
{
    public interface IDemoInvoiceRepository : IRepository<DemoInvoice>
    {
        /// <summary>
        /// Retrieve a saved configuration to generate a demo invoice.
        /// </summary>
        /// <param name="chatId">Unique identifier for chat.</param>
        /// <param name="messageId">Unique identifier for message.</param>
        /// <returns>A <see cref="DemoInvoice"/> object. <br />
        /// It can be null if the application has been restarted or if the invoice has already been generated.</returns>
        DemoInvoice? GetConfiguration(long chatId, int messageId);
    }
}
