// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using Microsoft.Extensions.Logging;
using Telegram.BotAPI;

namespace ShopBotNET.Core.Services
{
    /// <summary>
    /// It contains the main functionality of the telegram bot. <br />
    /// The application creates a new instance of this class to process each update received.
    /// </summary>
    public partial class ShopBot : TelegramBotBase<ShopBotProperties>
    {
        protected override void OnBotException(BotRequestException exp)
        {
            _logger.LogError("BotRequestException: {message}", exp.Message);
        }

        protected override void OnException(Exception exp)
        {
            _logger.LogError("Exception: {message}", exp.Message);
        }
    }
}
