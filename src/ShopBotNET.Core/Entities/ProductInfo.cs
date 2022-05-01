// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using Telegram.BotAPI.Payments;

namespace ShopBotNET.Core.Entities
{
    public class ProductInfo
    {
        public ProductInfo()
        {
        }

        public ProductInfo(string name, string description, string photoUrl, uint photoSize, uint photoWidth, uint photoHeight, string currency, IEnumerable<LabeledPrice> prices)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            PhotoUrl = photoUrl ?? throw new ArgumentNullException(nameof(photoUrl));
            PhotoSize = photoSize;
            PhotoWidth = photoWidth;
            PhotoHeight = photoHeight;
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
            Prices = prices ?? throw new ArgumentNullException(nameof(prices));

            Payload = Guid.NewGuid().ToString();
        }

        public string Name { get; }
        public string Description { get; }
        public string PhotoUrl { get; }
        public uint PhotoSize { get; }
        public uint PhotoWidth { get; }
        public uint PhotoHeight { get; }
        public string Payload { get; }
        public string Currency { get; }
        public uint? MaxTipAmount { get; set; }
        public bool NeedShippingAddress { get; set; }
        public bool IsFlexible { get; set; }

        public IEnumerable<LabeledPrice> Prices { get; }
        public IEnumerable<uint> SuggestedTipAmounts { get; set; }
    }
}
