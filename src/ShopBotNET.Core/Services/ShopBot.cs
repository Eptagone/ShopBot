// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using Microsoft.Extensions.Logging;
using ShopBotNET.Core.Data;
using Telegram.BotAPI;
using Telegram.BotAPI.AvailableMethods;
using Telegram.BotAPI.AvailableTypes;
using Telegram.BotAPI.Extensions;

namespace ShopBotNET.Core.Services;

/// <summary>
/// It contains the main functionality of the telegram bot. <br />
/// The application creates a new instance of this class to process each update received.
/// </summary>
public partial class ShopBot : SimpleTelegramBotBase
{
    private static User? Me;
    private readonly ILogger<ShopBot> logger;
    private readonly IShopDb db;
    private readonly ITelegramBotClient client;
    private readonly ShopBotProperties Properties;

    public ShopBot(ILogger<ShopBot> logger, ShopBotProperties properties, IShopDb db)
    {
        this.logger = logger;
        this.Properties = properties;
        this.db = db;
        this.client = properties.Client;

        Me ??= properties.Client.GetMe();
    }

    public string Name => Me!.FirstName;
    public string Username => Me!.Username!;
}
