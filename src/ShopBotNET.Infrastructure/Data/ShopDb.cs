﻿// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using ShopBotNET.Core.Data;

namespace ShopBotNET.Infrastructure.Data
{
    public sealed class ShopDb : IShopDb
    {
        public ShopDb(CacheDbContext context)
        {
            Products = new ProductRepository();

            States = new UserStateRepository(context);
            DemoInvoices = new DemoInvoiceRepository(context);
        }

        public IProducts Products { get; }

        public IUserStateRepository States { get; }
        public IDemoInvoiceRepository DemoInvoices { get; }
    }
}
