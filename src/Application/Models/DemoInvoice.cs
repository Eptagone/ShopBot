// Copyright (c) 2024 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

namespace ShopBotNET.Application.Models;

/// <summary>
/// Configuration to generate demo invoices
/// </summary>
public sealed class DemoInvoice
{
    public int Id { get; set; }
    public long ChatId { get; set; }
    public int MessageId { get; set; }

    public bool NeedName { get; set; }
    public bool NeedEmail { get; set; }
    public bool NeedPhone { get; set; }
    public bool NeedShippingAddress { get; set; } = true;

    public bool SendPhoto { get; set; } = true;
    public bool SendWebView { get; set; }

    public CurrencyCodes Currency { get; set; } = CurrencyCodes.USD;
}
