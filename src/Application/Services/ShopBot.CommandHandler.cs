// Copyright (c) 2024 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using Microsoft.Extensions.Caching.Memory;
using ShopBotNET.Application.Extensions;
using ShopBotNET.Application.Models;
using Telegram.BotAPI;
using Telegram.BotAPI.AvailableMethods;
using Telegram.BotAPI.AvailableTypes;
using Telegram.BotAPI.Extensions;
using MSG = ShopBotNET.Application.Resources.BotMessages;

namespace ShopBotNET.Application.Services;

/// <summary>
/// It contains the main functionality of the telegram bot. <br />
/// The application creates a new instance of this class to process each update received.
/// </summary>
partial class ShopBot : SimpleTelegramBotBase
{
    protected override void OnCommand(Message message, string commandName, string commandParameters)
    {
        switch (commandName)
        {
            case "start":
            case "help":
                {
                    var text = string.Format(MSG.Help, this.Username);
                    this.client.SendMessage(message.Chat.Id, text);
                }
                break;
            case "invoice":
                {
                    var demoInvoice = new DemoInvoice();
                    var keyboard = demoInvoice.GenInlineKeyboard();

                    var botMessage = this.client.SendMessage(
                        message.Chat.Id,
                        MSG.DemoInvoiceConfig,
                        parseMode: FormatStyles.HTML,
                        replyMarkup: keyboard
                    );

                    demoInvoice.ChatId = botMessage.Chat.Id;
                    demoInvoice.MessageId = botMessage.MessageId;
                    this.cache.Set($"{demoInvoice.ChatId}:{demoInvoice.MessageId}", demoInvoice);
                }
                break;
            case "support":
                this.client.SendMessage(message.Chat.Id, MSG.Support);
                this.CreateOrUpdateState(new UserState(message.Chat.Id));
                break;
            case "terms":
                this.client.SendMessage(message.Chat.Id, MSG.Terms);
                break;
            default:
                this.client.SendMessage(message.Chat.Id, MSG.UnknownCommand);
                break;
        }
    }
}
