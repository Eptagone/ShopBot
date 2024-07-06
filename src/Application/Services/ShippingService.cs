using Telegram.BotAPI.Payments;

namespace ShopBotNET.Application.Services;

class ShippingService : IShippingService
{
    /// <inheritdoc />
    public IEnumerable<ShippingOption> GetShippingOptions()
    {
        return
        [
            new("Free", "Free Shipping - Pigeons", [new("Shipping", 0)]),
            new("FedEx", "FedEx", [new("Shipping", 499), new("Handling", 299), new("Taxes", 100)]),
            new("DHL", "DHL", [new("Shipping", 599), new("Handling", 399), new("Taxes", 50)])
        ];
    }
}
