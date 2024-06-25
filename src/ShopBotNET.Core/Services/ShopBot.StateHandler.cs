// Copyright (c) 2022 Quetzal Rivera.
// Licensed under the GNU General Public License v3.0, See LICENCE in the project root for license information.

using ShopBotNET.Core.Entities;
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
	private void OnUserState(Message message, UserState state)
	{
		switch (state.Name)
		{
			case "support":
				{
					if (string.IsNullOrEmpty(message.Text))
					{
						this.client.SendMessage(message.Chat.Id, MSG.SupportInvalid);
					}
					else
					{
						this.client.SendMessage(message.Chat.Id, MSG.SupportResult);
						this.db.States.Delete(state);
					}
				}
				break;
		}
	}
}
