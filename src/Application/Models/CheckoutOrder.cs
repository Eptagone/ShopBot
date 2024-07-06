using Telegram.BotAPI.Payments;

namespace ShopBotNET.Application.Models;

/// <summary>
/// Represents a checkout order describing the product and shopping cart.
/// </summary>
/// <param name="Product">The product to be purchased.</param>
/// <param name="Currency">The currency to be used for the purchase.</param>
/// <param name="OtherPrices">Price breakdown.</param>
record CheckoutOrder(Product Product, string Currency, IEnumerable<LabeledPrice> OtherPrices)
{
    /// <summary>
    /// The maximum accepted amount for tips in the smallest units of the currency.
    /// </summary>
    public int? MaxTipAmount { get; set; }

    /// <summary>
    /// Optional. Pass True if you require the user's shipping address to complete the order. Ignored for payments in Telegram Stars.
    /// </summary>
    public bool NeedShippingAddress { get; set; }

    /// <summary>
    /// Optional. Pass True if the final price depends on the shipping method.
    /// </summary>
    public bool IsFlexible { get; set; }

    /// <summary>
    /// suggested amounts of tips in the smallest units of the currency.
    /// </summary>
    public IEnumerable<int> SuggestedTipAmounts { get; set; } = [];

    public IEnumerable<LabeledPrice> Prices =>
        new List<LabeledPrice>([new LabeledPrice("Subtotal", this.Product.Price)]).Concat(
            this.OtherPrices
        );
}
