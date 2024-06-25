// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

namespace ShopBotNET.Core.Data;

public interface IShopDb
{
	// Database data
	IProducts Products { get; }

	// Temporal data
	IUserStateRepository States { get; }
	IDemoInvoiceRepository DemoInvoices { get; }
}
