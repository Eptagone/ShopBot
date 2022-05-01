// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using System.ComponentModel.DataAnnotations;

namespace ShopBotNET.Core.Entities
{
    /// <summary>
    /// Configuration to generate demo invoices
    /// </summary>
    public sealed class DemoInvoice
    {
        public DemoInvoice()
        {
            NeedShippingAddress = true;
            SendPhoto = true;
            Currency = CurrencyCodes.USD;
        }

        [Key]
        public int Id { get; set; }
        public long ChatId { get; set; }
        public int MessageId { get; set; }

        public bool NeedName { get; set; }
        public bool NeedEmail { get; set; }
        public bool NeedPhone { get; set; }
        public bool NeedShippingAddress { get; set; }

        public bool SendPhoto { get; set; }
        public bool SendWebView { get; set; }

        public CurrencyCodes Currency { get; set; }
    }
}
