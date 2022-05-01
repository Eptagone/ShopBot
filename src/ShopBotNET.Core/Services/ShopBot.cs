// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using Microsoft.Extensions.Logging;
using ShopBotNET.Core.Data;
using Telegram.BotAPI;
using Telegram.BotAPI.AvailableTypes;

namespace ShopBotNET.Core.Services
{
    /// <summary>
    /// It contains the main functionality of the telegram bot. <br />
    /// The application creates a new instance of this class to process each update received.
    /// </summary>
    public partial class ShopBot : TelegramBotBase<ShopBotProperties>
    {
        private readonly ILogger<ShopBot> _logger;
        private readonly User _me;
        private readonly IShopDb _db;

        public ShopBot(ILogger<ShopBot> logger, ShopBotProperties botProperties, IShopDb db) : base(botProperties)
        {
            _logger = logger;
            _me = botProperties.User;
            _db = db;
        }
    }
}
