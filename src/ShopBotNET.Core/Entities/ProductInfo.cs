// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using Telegram.BotAPI.Payments;

namespace ShopBotNET.Core.Entities;

public class ProductInfo
{
	public ProductInfo()
	{
	}

	public ProductInfo(string name, string description, string photoUrl, int photoSize, int photoWidth, int photoHeight, string currency, IEnumerable<LabeledPrice> prices)
	{
		this.Name = name ?? throw new ArgumentNullException(nameof(name));
		this.Description = description ?? throw new ArgumentNullException(nameof(description));
		this.PhotoUrl = photoUrl ?? throw new ArgumentNullException(nameof(photoUrl));
		this.PhotoSize = photoSize;
		this.PhotoWidth = photoWidth;
		this.PhotoHeight = photoHeight;
		this.Currency = currency ?? throw new ArgumentNullException(nameof(currency));
		this.Prices = prices ?? throw new ArgumentNullException(nameof(prices));

		this.Payload = Guid.NewGuid().ToString();
	}

	public string Name { get; }
	public string Description { get; }
	public string PhotoUrl { get; }
	public int PhotoSize { get; }
	public int PhotoWidth { get; }
	public int PhotoHeight { get; }
	public string Payload { get; }
	public string Currency { get; }
	public int? MaxTipAmount { get; set; }
	public bool NeedShippingAddress { get; set; }
	public bool IsFlexible { get; set; }

	public IEnumerable<LabeledPrice> Prices { get; }
	public IEnumerable<int> SuggestedTipAmounts { get; set; }
}
