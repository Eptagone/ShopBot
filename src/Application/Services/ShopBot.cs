// Copyright (c) 2024 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Telegram.BotAPI;
using Telegram.BotAPI.AvailableMethods;
using Telegram.BotAPI.AvailableTypes;
using Telegram.BotAPI.Extensions;
using Telegram.BotAPI.GettingUpdates;

namespace ShopBotNET.Application.Services;

/// <summary>
/// It contains the main functionality of the telegram bot. <br />
/// The application creates a new instance of this class to process each update received.
/// </summary>
partial class ShopBot : SimpleTelegramBotBase
{
    private static User? Me;
    private readonly IMemoryCache cache;
    private readonly ILogger<ShopBot> logger;
    private readonly ITelegramBotClient client;
    private readonly IProductService productService;
    private readonly IShippingService shippingService;
    private readonly string providerToken;

    public ShopBot(
        ILogger<ShopBot> logger,
        IOptions<ShopBotOptions> options,
        IProductService productService,
        IShippingService shippingService,
        ITelegramBotClient client,
        IMemoryCache cache
    )
    {
        this.logger = logger;
        this.client = client;
        this.productService = productService;
        this.shippingService = shippingService;
        this.cache = cache;

        this.providerToken = options.Value.ProviderToken;

        Me ??= client.GetMe();
    }

    public string Username => Me!.Username!;
}
