// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using ShopBotNET.Core.Entities;
using ShopBotNET.Core.Extensions;
using Telegram.BotAPI;
using Telegram.BotAPI.AvailableMethods;
using Telegram.BotAPI.AvailableMethods.FormattingOptions;
using Telegram.BotAPI.AvailableTypes;
using MSG = ShopBotNET.Core.Resources.BotMessages;

namespace ShopBotNET.Core.Services
{
    /// <summary>
    /// It contains the main functionality of the telegram bot. <br />
    /// The application creates a new instance of this class to process each update received.
    /// </summary>
    public partial class ShopBot : TelegramBotBase<ShopBotProperties>
    {
        protected override void OnCommand(Message message, string commandName, string commandParameters)
        {
            switch (commandName)
            {
                case "start":
                case "help":
                    {
                        var text = string.Format(MSG.Help, _me.Username);
                        Api.SendMessage(message.Chat.Id, text);
                    }
                    break;
                case "invoice":
                    {
                        var demoInvoice = new DemoInvoice();
                        var keyboard = demoInvoice.GenInlineKeyboard();

                        var botMessage = Api.SendMessage(message.Chat.Id, MSG.DemoInvoiceConfig, ParseMode.HTML, replyMarkup: keyboard);

                        demoInvoice.ChatId = botMessage.Chat.Id;
                        demoInvoice.MessageId = botMessage.MessageId;
                        _db.DemoInvoices.Insert(demoInvoice);
                    }
                    break;
                case "support":
                    Api.SendMessage(message.Chat.Id, MSG.Support);
                    _db.States.Insert(new UserState(message.Chat.Id, "support"));
                    break;
                case "terms":
                    Api.SendMessage(message.Chat.Id, MSG.Terms);
                    break;
                default:
                    Api.SendMessage(message.Chat.Id, MSG.UnknownCommand);
                    break;
            }
        }
    }
}
