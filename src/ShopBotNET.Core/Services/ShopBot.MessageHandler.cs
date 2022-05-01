// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using Telegram.BotAPI;
using Telegram.BotAPI.AvailableMethods;
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
        protected override void OnMessage(Message message)
        {
            if (!string.IsNullOrEmpty(message.Text) && message.Text.StartsWith('/'))
            {
                base.OnMessage(message);
            }
            else if (message.SuccessfulPayment != null)
            {
                // In Production, you mush check payment info in message.SuccessfulPayment.
                Api.SendMessage(message.Chat.Id, MSG.SuccessfulPayment);
            }
            else
            {
                var state = _db.States.GetLastState(message.Chat.Id);

                if (state == null)
                {
                    var text = string.Format(MSG.Help, _me.Username);
                    Api.SendMessage(message.Chat.Id, text);
                }
                else
                {
                    OnUserState(message, state);
                }
            }
        }
    }
}
