// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using ShopBotNET.Core.Data;
using ShopBotNET.Core.Entities;

namespace ShopBotNET.Infrastructure.Data
{
    public sealed class DemoInvoiceRepository : RepositoryBase<CacheDbContext, DemoInvoice>, IDemoInvoiceRepository
    {
        public DemoInvoiceRepository(CacheDbContext context) : base(context)
        {
        }

        public DemoInvoice? GetConfiguration(long chatId, int messageId) => _context.DemoInvoices.FirstOrDefault(d => d.ChatId == chatId && d.MessageId == messageId);
    }
}
