// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using Telegram.BotAPI.AvailableMethods;
using Telegram.BotAPI.AvailableTypes;
using Telegram.BotAPI.Extensions;
using MSG = ShopBotNET.Core.Resources.BotMessages;

namespace ShopBotNET.Core.Services;

/// <summary>
/// It contains the main functionality of the telegram bot. <br />
/// The application creates a new instance of this class to process each update received.
/// </summary>
public partial class ShopBot : SimpleTelegramBotBase
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
			this.client.SendMessage(message.Chat.Id, MSG.SuccessfulPayment);
		}
		else
		{
			var state = this.db.States.GetLastState(message.Chat.Id);

			if (state == null)
			{
				var text = string.Format(MSG.Help, this.Username);
				this.client.SendMessage(message.Chat.Id, text);
			}
			else
			{
				this.OnUserState(message, state);
			}
		}
	}
}
