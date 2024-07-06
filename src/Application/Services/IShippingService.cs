using Telegram.BotAPI.Payments;

namespace ShopBotNET.Application.Services;

/// <summary>
/// Provides methods related to shipping.
/// </summary>
interface IShippingService
{
    /// <summary>
    /// Get the available shipping options.
    /// </summary>
    /// <returns>A list of <see cref="ShippingOption"/> objects.</returns>
    IEnumerable<ShippingOption> GetShippingOptions();
}
