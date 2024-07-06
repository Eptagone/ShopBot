// Copyright (c) 2024 Quetzal Rivera.

// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using Microsoft.Extensions.Logging;
using Telegram.BotAPI;
using Telegram.BotAPI.Extensions;

namespace ShopBotNET.Application.Services;

/// <summary>
/// It contains the main functionality of the telegram bot. <br />
/// The application creates a new instance of this class to process each update received.
/// </summary>
partial class ShopBot : SimpleTelegramBotBase
{
    protected override void OnBotException(BotRequestException exp)
    {
        this.logger.LogError("BotRequestException: {message}", exp.Message);
    }

    protected override void OnException(Exception exp)
    {
        this.logger.LogError("Exception: {message}", exp.Message);
    }
}
